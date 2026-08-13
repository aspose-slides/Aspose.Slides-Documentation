---
title: Obter Propriedades Efetivas de Forma de Apresentações em C++
linktitle: Propriedades Efetivas
type: docs
weight: 50
url: /pt/cpp/shape-effective-properties/
keywords:
- propriedades de forma
- propriedades de câmera
- rig de iluminação
- forma chanfrada
- quadro de texto
- estilo de texto
- altura da fonte
- formato de preenchimento
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a usar o Aspose.Slides para C++ para distinguir a formatação local, herdada e efetiva de formas em apresentações do PowerPoint."
---
## **Entender Propriedades Locais, Herdadas e Efetivas**

A formatação do PowerPoint pode provir de vários locais. O valor armazenado diretamente em um objeto é seu **valor local**. Se esse valor não estiver definido, o PowerPoint procura nas fontes de formatação pai, como o padrão de parágrafo, um estilo de texto, um layout ou slide mestre, um tema ou os padrões ao nível da apresentação. Esses valores são **valores herdados**. O valor que permanece após toda a hierarquia ser resolvida é o **valor efetivo** — o valor usado para renderizar o objeto.

Por exemplo, uma porção de texto pode não definir sua própria altura de fonte. Sua altura da fonte local [font height](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseportionformat/) é então `std::numeric_limits<float>::quiet_NaN()`, que significa "não definido aqui". A porção pode herdar uma altura do seu parágrafo, do estilo de texto padrão da apresentação ou de outra fonte aplicável. Chamar [GetEffective](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportionformat/) no formato da porção retorna a altura final resolvida.

Use os dois tipos de dados de formatação para diferentes propósitos:

- Leia ou altere um objeto de formato local, como [IPortionFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportionformat/), quando precisar controlar onde um valor é definido.
- Leia um objeto de dados efetivos, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportionformateffectivedata/), quando precisar do resultado final renderizado. Dados efetivos são somente leitura.

## **Comparar Valores Locais, Herdados e Efetivos**

O exemplo completo a seguir cria uma forma e aplica alturas de fonte nos níveis de apresentação, parágrafo e porção. Cada etapa imprime os valores definidos nesses níveis e o valor efetivo resultante para a mesma porção de texto. Também demonstra por que os dados efetivos precisam ser lidos novamente após alterações de formatação.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// Define valores herdados em dois níveis diferentes.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // Leia os dados efetivos após as alterações anteriores.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// Um valor local na porção sobrescreve ambos os valores herdados.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// Alterar um valor herdado não sobrescreve um valor local existente.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// Limpe o valor local. A porção agora herda novamente do parágrafo.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// Limpe o valor do parágrafo. O padrão da apresentação agora fornece o resultado.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A prioridade neste exemplo é a formatação local da porção, seguida da formatação de parágrafo, e então o padrão da apresentação. Outros objetos podem ter cadeias de herança diferentes, mas o princípio é o mesmo: um valor explícito mais específico vence, e [GetEffective](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportionformat/) retorna o resultado final.

## **Obter Propriedades de Texto Efetivas**

A formatação de texto está distribuída em vários objetos:

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframeformat/) resolve as propriedades de quadros de texto como margens, ancoragem, ajuste automático e direção vertical do texto.
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextstyle/) resolve a formatação de parágrafo para cada nível de estilo de texto.
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/) resolve propriedades de parágrafo como alinhamento, recuo e marcadores.
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportionformat/) resolve propriedades de caracteres como altura da fonte, família tipográfica, cor, negrito e itálico.

Para o próximo exemplo, `text-formatting.pptx` deve conter ao menos um slide e um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) com um quadro de texto não vazio. O IAutoShape pode aparecer em qualquer posição na coleção de formas; o código procura um objeto adequado e o valida antes do uso.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **Obter Propriedades 3D Efetivas**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/) retorna um objeto [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformateffectivedata/) que agrupa todas as configurações 3D resolvidas. Seus dados de [camera](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icameraeffectivedata/), [light rig](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilightrigeffectivedata/), [top bevel](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapebeveleffectivedata/) e [bottom bevel](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapebeveleffectivedata/) expõem as respectivas configurações efetivas. Ler essas configurações relacionadas em conjunto facilita a compreensão da aparência 3D final de uma forma.

Para este exemplo, `shape-3d.pptx` deve conter ao menos uma forma no seu primeiro slide. Aplique configurações de câmera 3D, iluminação ou chanfradura a essa forma se desejar que a saída contenha valores diferentes dos padrões.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **Obter Formatação de Tabela Efetiva**

A formatação de tabela pode vir do estilo da tabela e de formatos aplicados a toda a tabela, a uma coluna, a uma linha ou a uma célula individual. Para conflitos entre preenchimentos definidos explicitamente, a prioridade é célula, linha, coluna e, por fim, toda a tabela. O formato efetivo de uma célula é o formato final usado para desenhar essa célula.

Para este exemplo, `table-formatting.pptx` deve conter ao menos uma tabela no seu primeiro slide. A tabela deve ter ao menos uma linha e uma coluna. O código procura um [ITable](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itable/) em vez de supor que a primeira forma seja uma tabela.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

Se precisar da cor em vez de apenas o tipo de preenchimento, primeiro verifique o [FillType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifillformateffectivedata/) efetivo, e então leia a propriedade que se aplica a esse tipo — por exemplo, [SolidFillColor](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifillformateffectivedata/) para um preenchimento sólido.

## **Ler Dados Efetivos Novamente Após Alterações**

Os dados efetivos descrevem a hierarquia de formatação no momento em que são resolvidos. Chame `GetEffective` novamente após alterar qualquer coisa que possa participar dessa hierarquia, incluindo:

- a formatação local do objeto;
- padrões de parágrafo ou de quadro de texto;
- um estilo de tabela, tabela, coluna, linha ou formato de célula;
- formatação de layout ou slide mestre;
- dados de tema ou padrões ao nível da apresentação;
- o layout ou mestre atribuído a um slide.

Não mantenha um objeto de dados efetivos como uma captura permanente. Aspose.Slides pode armazenar em cache alguns dados efetivos internamente, e uma chamada posterior a `GetEffective` pode atualizar esses dados. Se precisar comparar valores antes e depois de uma alteração, copie os valores escalares necessários — como a altura da fonte, cor, alinhamento ou largura da chanfradura — para suas próprias variáveis antes de fazer a mudança.

Para mudar um valor, atualize o objeto de formato local apropriado e então chame `GetEffective` para verificar o resultado. Os próprios objetos de dados efetivos são somente leitura.

## **FAQ**

**Como posso saber qual nível forneceu um valor efetivo?**

Os dados efetivos contêm o valor final, não sua origem. Inspecione os objetos locais aplicáveis do nível mais específico para fora. Para texto, isso pode incluir a porção, parágrafo, quadro de texto, layout, mestre, tema e padrões da apresentação. Valores indefinidos como `std::numeric_limits<float>::quiet_NaN()` ou `nullptr` indicam que a busca continua para outro nível.

**O que acontece quando nenhum nível define uma propriedade?**

O Aspose.Slides resolve o padrão apropriado do PowerPoint ou da biblioteca. Esse valor resolvido aparece nos dados efetivos mesmo que nenhum objeto local o defina explicitamente.

**Por que um valor efetivo às vezes é igual ao valor local?**

O valor local venceu o cálculo de herança. Isso é esperado quando a propriedade está explicitamente definida no objeto e nenhuma regra mais específica a sobrescreve.

**Quando devo usar dados locais em vez de dados efetivos?**

Use dados locais para inspecionar ou editar um nível específico de formatação. Use dados efetivos quando precisar da aparência final após herança, regras de tema e estilos aplicáveis terem sido resolvidos. O [exemplo de comparação completa](#compare-local-inherited-and-effective-values) demonstra ambos no mesmo fluxo de trabalho.