---
title: Gerenciar Formas de Apresentação em C++
linktitle: Manipulação de Formas
type: docs
weight: 40
url: /pt/cpp/shape-manipulations/
keywords:
  - Forma PowerPoint
  - Forma de apresentação
  - Forma no slide
  - Encontrar forma
  - Clonar forma
  - Remover forma
  - Ocultar forma
  - Alterar ordem da forma
  - Obter ID da forma interop
  - Texto alternativo da forma
  - Formatos de layout da forma
  - Forma como SVG
  - Forma para SVG
  - Alinhar forma
  - Inverter forma
  - PowerPoint
  - apresentação
  - C++
  - Aspose.Slides
description: "Aprenda como identificar, clonar, remover, ocultar, reorganizar, exportar, alinhar e inverter formas de apresentação com Aspose.Slides para C++."
---
## **Visão geral**

Aspose.Slides for C++ representa as formas em um slide como uma [IShapeCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/) ordenada. A coleção é tanto o local onde você encontra e modifica formas quanto a fonte da ordem de sobreposição: o índice `0` é a forma mais ao fundo, enquanto o último índice é a forma mais à frente.

Este artigo segue esse modelo. Primeiro explica como identificar uma forma de forma confiável, depois mostra como clonar, remover, ocultar e reorganizar formas. As seções finais cobrem formatação no nível de layout, exportação SVG, alinhamento e configurações de inversão. Cada exemplo é independente, de modo que você pode usar apenas as operações que seu fluxo de trabalho requer.

## **Identificar e Encontrar Formas**

Os índices da coleção são convenientes ao processar um arquivo conhecido, mas não são identificadores estáveis. Adicionar, remover ou reorganizar uma forma pode mudar seu índice. Escolha um identificador de acordo com a forma como a apresentação foi criada e mantida:

- [Name](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_name/) é útil para modelos controlados por desenvolvedores e é fácil de inspecionar no Painel de Seleção do PowerPoint. Nomes podem ser editados e não são garantidos como únicos, portanto estabeleça uma convenção de nomenclatura se o código depender deles.
- [AlternativeText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_alternativetext/) é útil quando uma descrição de acessibilidade ou uma tag fornecida pelo autor já identifica a forma. É visível aos usuários, pode ser localizado ou reescrito para acessibilidade, e não é garantido como único. Não reutilize silenciosamente texto de acessibilidade significativo como chave de banco de dados.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_officeinteropshapeid/) é um identificador somente leitura que é único dentro de um slide e corresponde ao ID de forma usado pelo interop do PowerPoint. Use-o ao integrar com o PowerPoint ou quando precisar de uma referência inequívoca durante a vida útil de uma forma. Uma forma clonada ou recriada é uma forma diferente e recebe seu próprio ID.

A propriedade relacionada [UniqueId](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_uniqueid/) tem escopo de apresentação, mas destina‑se a complementos e pode ser reatribuída. Não deve ser tratada como uma chave externa permanente. Se a identidade a longo prazo for essencial, mantenha o mapeamento nos dados da aplicação e valide se a forma esperada ainda existe.

O exemplo a seguir pesquisa por `Name` e relata o ID de interop com escopo de slide. Quando o modelo não contém a forma esperada, o código relata esse resultado em vez de continuar com o objeto errado.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

Quando uma operação é específica a um tipo de forma, verifique a interface antes de usar membros específicos de tipo. Este exemplo atualiza texto e texto alternativo somente se o objeto nomeado for um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **Modificar a Coleção de Formas**

Os métodos de adicionar, clonar, remover e reorganizar operam na coleção imediatamente. Se uma operação altera o número ou a ordem das formas, não continue a confiar em índices capturados antes dessa operação.

### **Clonar uma Forma**

[AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/addclone/) cria uma cópia independente e a anexa à coleção de destino. [InsertClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/insertclone/) também cria uma cópia, mas a coloca em um índice de ordem Z especificado. As sobrecargas que aceitam coordenadas movem a cópia sem alterar seu tamanho; as sobrecargas com largura e altura podem redimensioná‑la também.

O exemplo cria um slide de destino, clona um retângulo rotulado para a frente e insere um segundo clone no fundo. Alterações em qualquer um dos clones não modificam a forma de origem.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Clonar copia o conteúdo e a formatação da forma, incluindo seu nome e texto alternativo. Atribua novos identificadores lógicos ao clone quando esses valores precisarem ser únicos. Recursos usados por formas complexas são gerenciados pela apresentação, mas um clone permanece como um novo item da coleção com uma nova identidade de forma.

### **Remover Formas**

[Remove](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/remove/) exclui um objeto de forma específico de sua coleção. Ao remover múltiplas correspondências durante iteração indexada, percorra do final para que cada índice restante permaneça válido.

Este exemplo remove toda forma com um nome designado. Ele lê a forma indexada atual, não um item fixo da coleção, e não faz cast da forma desnecessariamente.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Após a remoção, a contagem de formas e os índices das formas subsequentes mudam. Referências a formas não afetadas permanecem mais confiáveis que índices armazenados. Considere também conectores, animações e outros recursos da apresentação que podem referir‑se ao objeto removido; remover uma forma visível pode alterar mais do que a aparência do slide.

### **Ocultar uma Forma**

Definir [Hidden](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/set_hidden/) como `true` mantém a forma na coleção, mas impede que ela apareça na exibição normal de slide. Seu índice, formatação e conteúdo permanecem disponíveis ao código, portanto ocultar é apropriado para elementos opcionais que podem ser restaurados depois.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ocultar não é exclusão nem segurança. O objeto ainda pode ser descoberto e desocultado por um usuário ou por código, e continua fazendo parte do arquivo da apresentação.

### **Alterar a Ordem Z**

Formas sobrepostas são pintadas na ordem da coleção. [Reorder](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/reorder/) move uma forma existente para um índice de destino sem cloná‑la. O índice `0` é o fundo; `Count - 1` é a frente.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O retângulo é criado primeiro e inicialmente fica atrás da elipse. Movê‑lo para o índice final coloca‑o na frente. Finalize a ordem Z depois de adicionar ou clonar todas as formas relacionadas, pois essas operações inserem novos itens na coleção e podem alterar a pilha pretendida.

## **Inspecionar Formas em Slides de Layout**

Slides normais, slides de layout e slides mestres possuem coleções de formas separadas. Uma forma na coleção de layout não é o mesmo objeto que uma forma posicionada de forma semelhante em um slide normal. Inspecione as formas de layout quando precisar entender ou alterar a formatação fornecida por um layout.

O exemplo a seguir lê o [FillFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_fillformat/) e o [LineFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_lineformat/) de cada forma de layout sem assumir que toda forma seja um `AutoShape`.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

Editar um layout pode afetar vários slides que o utilizam. Antes de mudar uma forma de layout, determine se um slide normal herda o objeto ou contém uma sobrescrita local, e teste cada slide que usa esse layout.

## **Exportar uma Forma para SVG**

[WriteAsSvg](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/writeassvg/) grava o conteúdo renderizado de uma forma em um fluxo. O resultado contém a forma, não o plano de fundo inteiro do slide nem as formas vizinhas.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

Mantenha a apresentação aberta durante a renderização. A saída depende da formatação da forma e de recursos como fontes e imagens. Se precisar da composição completa, exporte o slide em vez de uma forma individual. O chamador possui o fluxo e deve fechá‑lo ou descartá‑lo.

## **Alinhar Formas**

Os overloads de [SlideUtil::AlignShapes](https://reference.aspose.com/slides/pt/cpp/aspose.slides.util/slideutil/alignshapes/) alinham todas as formas ou índices de coleção selecionados. [ShapesAlignmentType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shapesalignmenttype/) especifica a borda, linha central ou modo de distribuição. Defina `alignToSlide` como `true` para usar as bordas do slide; defina como `false` para alinhar as formas selecionadas em relação umas às outras.

Este exemplo alinha três formas ao topo do slide. As referências de forma retornadas são convertidas para seus índices atuais imediatamente antes do alinhamento.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Alinhar altera posições, não a ordem Z. O alinhamento relativo normalmente requer pelo menos duas formas, enquanto distribuição horizontal ou vertical precisa de formas suficientes para definir o espaçamento. Recalcule os índices se modificar a coleção antes de chamar o método.

## **Inverter uma Forma**

A classe [ShapeFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shapeframe/) armazena posição, tamanho, configurações de inversão horizontal e vertical, e rotação. Seus valores `FlipH` e `FlipV` utilizam [NullableBool](https://reference.aspose.com/slides/pt/cpp/aspose.slides/nullablebool/): `True` habilita a inversão, `False` desabilita, e `NotDefined` preserva o estado não especificado/padrão.

A apresentação de entrada abaixo contém uma forma não invertida.

![The shape before flipping](shape_to_be_flipped.png)

O exemplo preserva todos os demais valores de frame e substitui apenas as duas configurações de inversão. Isso é importante porque atribuir um novo [Frame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/set_frame/) substitui o frame completo.

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A forma salva é espelhada horizontal e verticalmente enquanto mantém sua posição, tamanho e rotação.

![The shape after flipping](flipped_shape.png)

## **Perguntas Frequentes**

**Devo usar um índice de coleção como identificador de forma?**

Somente para processamento de curta duração quando a coleção não mudará antes do uso do índice. Prefira uma convenção validada de `Name` ou `AlternativeText` para modelos criados, ou `OfficeInteropShapeId` para trabalhos de interop com escopo de slide.

**Ocultar uma forma a remove da ordem Z?**

Não. Uma forma oculta permanece na coleção no mesmo índice. Ela pode ser encontrada, reordenada, editada ou tornada visível novamente.

**Por que uma forma clonada apareceu à frente de outra forma?**

`AddClone` anexa o clone ao final da coleção, que é a frente da ordem Z. Use `InsertClone` para escolher o índice inicial ou `Reorder` depois que todas as formas foram adicionadas.