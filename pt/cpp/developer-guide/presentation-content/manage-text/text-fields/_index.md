---
title: Gerenciar campos de texto em apresentações PowerPoint em C++
linktitle: Campos de Texto
type: docs
weight: 52
url: /pt/cpp/text-fields/
keywords:
- campo de texto
- texto automático
- número do slide
- data e hora
- cabeçalho
- rodapé
- porção de texto
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Criar, inspecionar, modificar e remover campos de texto em apresentações PowerPoint com Aspose.Slides para C++. Preservar a formatação e verificar os arquivos PPTX e PPT salvos."
---
## **Visão geral**

Um parágrafo de texto consiste em porções. Uma [IPortion](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/) normal contém texto literal; uma porção de campo também possui um [IField](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifield/) cujo tipo identifica um valor atualizado automaticamente, como número do slide ou data. Duas porções podem exibir os mesmos caracteres enquanto apenas uma contém um campo.

Use [IPortion::get_Field](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/get_field/) para distingui‑las: ele devolve `nullptr` para texto normal. [IPortion::AddField](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/addfield/) converte uma porção existente em um campo. Mantenha um rótulo e seu valor dinâmico em porções separadas para que a conversão do valor não substitua também o rótulo.

Este guia abrange campos dentro de texto, sua formatação e a gravação deles em PPTX e PPT. Para quadros de texto e parágrafos, consulte [Gerenciar Texto](/slides/pt/cpp/manage-text/).

## **Criar um campo de número do slide**

O exemplo a seguir cria uma caixa de texto contendo um rótulo literal `Slide ` seguido de um número atualizado automaticamente. Ele define o tamanho, peso e cor do número antes de adicionar o campo, então reabre a apresentação salva e verifica o tipo, texto e formatação do campo. Nenhum arquivo de entrada é necessário.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

A nova apresentação começa com o número do slide 1, portanto o texto esperado é `Slide 1`, e ambas as verificações devem imprimir `True`. O número permanece um campo após a reabertura; não é um literal `1`. O casting e os índices na verificação referem‑se à forma e às porções criadas por este exemplo.

## **Escolher um tipo de campo**

[FieldType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fieldtype/) implementa [IFieldType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifieldtype/) e fornece os valores predefinidos a seguir. Passe o valor apropriado para [AddField](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/addfield/).

| Acessor | Propósito |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fieldtype/get_slidenumber/) | O número atual do slide. |
| [get_DateTime](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fieldtype/get_datetime/) | Data/hora no formato padrão do aplicativo de renderização. |
| [get_DateTime1](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fieldtype/get_datetime9/) | Formatos de data ou data/hora combinados predefinidos. |
| [get_DateTime10](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fieldtype/get_datetime13/) | Formatos de hora predefinidos, com opções para segundos e relógio de 12 horas. |
| [get_Header](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fieldtype/get_header/) | Um campo de cabeçalho; veja as limitações de marcador de posição e formato abaixo. |
| [get_Footer](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fieldtype/get_footer/) | Um campo de rodapé. |

Por exemplo, [get_DateTime3](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fieldtype/get_datetime3/) fornece dia, nome completo do mês e ano em inglês. Estes são formatos de campo predefinidos, não cadeias arbitrárias de formato de data. O idioma da porção, definido com [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseportionformat/set_languageid/), e o aplicativo que processa a apresentação podem afetar o resultado exibido.

## **Criar um campo a partir de uma string interna**

A sobrecarga de string de [AddField](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/addfield/) aceita um identificador interno de campo. Use‑a ao preservar um identificador fornecido por outro aplicativo que não possua um valor predefinido. Também é possível construir um [FieldType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fieldtype/fieldtype/) a partir do identificador. [IFieldType::get_InternalString](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifieldtype/get_internalstring/) expõe esse identificador para inspeção.

Este exemplo armazena um campo específico de aplicação `custom-report-id` com o texto de fallback `Report-042`. Nenhum arquivo de entrada é necessário. O identificador não registra um cálculo: Aspose.Slides não gera IDs de relatório para um tipo desconhecido. O aplicativo que compreende esse identificador deve fornecer seu significado e atualizar seu valor.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

Após esta ida‑e‑volta em PPTX, o tipo esperado é `custom-report-id` e o texto esperado é `Report-042`. Passar uma string como `yyyy-MM-dd` nomearia um tipo de campo; não configuraria um formato de data personalizado. Para uma data fixa em formato arbitrário, use texto normal.

## **Inspecionar, modificar e remover campos de data/hora**

Leia um tipo de campo existente através de [IField::get_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifield/get_type/) e altere‑o via [IField::set_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifield/set_type/). Verifique se o campo existe antes de acessar seu tipo. Para interromper atualizações automáticas, chame [IPortion::RemoveField](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/removefield/). Isso mantém a porção e seu texto atual enquanto remove a associação ao campo. Se precisar de um valor fixo específico, atribua esse texto após remover o campo.

Para a configuração de API associada ao processamento de campos de data/hora, veja [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/set_currentdatetime/). O exemplo abaixo usa uma data de aprovação explícita ao converter um campo em texto normal.

Baixe [sample.pptx](sample.pptx) e coloque‑o no diretório de trabalho. Ele contém duas formas de texto nomeadas, `UpdatedAt` e `ApprovedDate`, cada uma com um campo de data/hora, além de rótulos de texto normais. O exemplo a seguir percorre as formas de texto de nível superior em slides regulares. Ele altera campos de data/hora para um formato de data longa e os torna itálicos, preservando sua outra formatação. Apenas os campos em `ApprovedDate` tornam‑se texto fixo.

O exemplo reconhece os identificadores internos incorporados `datetime` e `datetime1` até `datetime13`. Grupos, tabelas, notas, layouts e mestres exigem percorrer seus próprios contêineres de texto e estão fora do escopo deste exemplo.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

Após reabrir, `UpdatedAt` deve ter o tipo `datetime3` e permanecer dinâmico. `ApprovedDate` não deve ter campo e deve conter `05 April 2030`. Ambas as porções de data são itálicas, e seu tamanho de fonte original, configuração de negrito e cor permanecem intactos. Os rótulos de texto normais permanecem inalterados. A verificação lê a primeira porção das duas formas conhecidas no exemplo fornecido.

## **Preservar a formatação do texto**

Trabalhe com a porção existente ao adicionar um campo, mudar seu tipo ou removê‑lo. Essas operações mantêm a formatação dessa porção. Use [IPortion::get_PortionFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/get_portionformat/) para alterar apenas as propriedades necessárias, como os exemplos fazem para cor ou itálico.

Evite reconstruir um quadro de texto inteiro apenas para atualizar um campo: isso pode perder os limites originais das porções e sua formatação individual. Também distinga formatação explicitamente definida da herdada do parágrafo, layout ou tema. Consulte [Formatação de Texto](/slides/pt/cpp/text-formatting/) para opções mais amplas de formatação.

## **Campos e marcadores de posição de cabeçalho/rodapé**

Um campo faz parte de uma porção de texto. Um marcador de posição é uma forma com um papel na apresentação, como rodapé ou número do slide. Adicionar um campo a uma caixa de texto normal não transforma essa forma em um marcador de posição.

Os gerenciadores de cabeçalho/rodapé controlam o texto e a visibilidade dos marcadores de posição em slides, layouts e mestres, incluindo a propagação para slides dependentes. Um campo numérico em uma caixa de texto personalizada pode ser útil mesmo quando você não usa o marcador de posição de número do slide. Por outro lado, alterar a visibilidade do marcador de posição não remove um campo de uma caixa de texto não relacionada.

Os tipos predefinidos de cabeçalho e rodapé não criam os marcadores de posição correspondentes nem fornecem seu conteúdo. Em particular, um slide PowerPoint padrão não tem marcador de posição de cabeçalho; cabeçalhos pertencem a páginas de notas e folhetos. Não presuma que um campo de cabeçalho ou rodapé em uma forma arbitrária obterá automaticamente o texto configurado por meio de um gerenciador de marcadores de posição. Para esse fluxo de trabalho, veja [Cabeçalhos e Rodapés da Apresentação](/slides/pt/cpp/presentation-header-and-footer/).

## **Limitações de PPTX e PPT**

Verifique tanto o tipo de campo quanto o texto resultante após salvar e reabrir. Preservar um identificador não prova que um aplicativo possa calcular ou exibir seu valor.

| Formato | Comportamento e limitações do campo |
|---|---|
| PPTX | Armazena identificadores internos de campo juntamente com o texto do campo. Use os exemplos acima para verificar tipos predefinidos e identificadores personalizados após salvar e reabrir. Um tipo personalizado desconhecido não adquire lógica de cálculo automática. Outro aplicativo pode tratar identificadores não suportados de forma diferente. |
| PPT | Usa representações legadas de campo e tem compatibilidade mais limitada. Campos de número de slide e campos de data/hora predefinidos têm representações legadas. Campos personalizados não suportados ou campos de cabeçalho em uma caixa de texto de slide normal podem produzir `*` como texto. Não confie que campos personalizados ou contextos de campo não suportados retenham seu texto visível. |

Para saída fixa e portátil, converta campos não suportados em texto normal e atribua explicitamente o valor desejado antes de salvar. Isso preserva o texto escolhido, mas interrompe intencionalmente as atualizações automáticas. Teste também o aplicativo de destino quando sua própria recalculação de campo fizer parte do seu fluxo de trabalho.

## **Perguntas frequentes**

**Como posso saber se um número ou data exibido é um campo?**

Inspecione [IPortion::get_Field](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/get_field/). Um valor não nulo identifica um campo; o texto exibido sozinho não pode dizer isso.

**Remover um campo remove seu texto ou formatação?**

Não. [RemoveField](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/removefield/) converte a porção existente em texto normal. Atribua um valor explícito depois, se precisar de uma data fixa ou valor de fallback.

**Uma string interna pode definir um novo formato de data ou fórmula?**

Não. Ela identifica um tipo de campo. Um identificador desconhecido não fornece um avaliador nem um padrão de formato de data. Use um tipo predefinido suportado ou formate o valor você mesmo como texto normal.

**Por que verificar a apresentação novamente após salvá‑la?**

Identificadores de campo, texto calculado e formatação são coisas distintas a ser verificadas. A conversão de formato pode alterar o resultado visível mesmo quando o identificador do campo ainda está presente.