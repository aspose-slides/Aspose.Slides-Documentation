---
title: Gerenciar Campos de Texto em Apresentações PowerPoint no .NET
linktitle: Campos de Texto
type: docs
weight: 52
url: /pt/net/text-fields/
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
- C#
- Aspose.Slides
description: "Crie, inspecione, modifique e remova campos de texto em apresentações PowerPoint com Aspose.Slides para .NET. Preserve a formatação e verifique arquivos PPTX e PPT salvos."
---
## **Visão geral**

Um parágrafo de texto consiste em porções. Uma [IPortion](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/) ordinária contém texto literal; uma porção de campo também possui um [IField](https://reference.aspose.com/slides/pt/net/aspose.slides/ifield/) cujo tipo identifica um valor atualizado automaticamente, como o número do slide ou a data. Duas porções podem exibir os mesmos caracteres enquanto apenas uma contém um campo.

Use [IPortion.Field](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/field/) para distingui‑las: ele é `null` para texto ordinário. [IPortion.AddField](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/addfield/) converte uma porção existente em um campo. Mantenha um rótulo e seu valor dinâmico em porções separadas para que a conversão do valor não substitua também o rótulo.

Este guia cobre campos dentro de texto, sua formatação e a gravação deles em PPTX e PPT. Para quadros de texto e parágrafos, veja [Manage Text](/slides/pt/net/manage-text/).

## **Criar um Campo de Número de Slide**

O exemplo completo a seguir cria uma caixa de texto contendo um rótulo literal `Slide ` seguido por um número atualizado automaticamente. Ele define o tamanho, estilo e cor do número antes de adicionar o campo, então reabre a apresentação salva e verifica o tipo de campo, o texto e a formatação. Nenhum arquivo de entrada é necessário.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

A nova apresentação começa com o número de slide 1, portanto o texto é `Slide 1`, e ambas as verificações imprimem `True`. O número permanece um campo após reabrir; não é um literal `1`. Os casts e índices na verificação referem‑se à forma e às porções criadas por este exemplo.

## **Escolher um Tipo de Campo**

[FieldType](https://reference.aspose.com/slides/pt/net/aspose.slides/fieldtype/) implementa [IFieldType](https://reference.aspose.com/slides/pt/net/aspose.slides/ifieldtype/) e fornece os seguintes valores predefinidos. Passe o valor apropriado para [AddField](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/addfield/).

| Valor | Propósito |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/pt/net/aspose.slides/fieldtype/slidenumber/) | O número do slide atual. |
| [DateTime](https://reference.aspose.com/slides/pt/net/aspose.slides/fieldtype/datetime/) | Data/hora no formato padrão do aplicativo de renderização. |
| [DateTime1](https://reference.aspose.com/slides/pt/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/pt/net/aspose.slides/fieldtype/datetime9/) | Formatos de data predefinidos ou combinações de data/hora. |
| [DateTime10](https://reference.aspose.com/slides/pt/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/pt/net/aspose.slides/fieldtype/datetime13/) | Formatos de hora predefinidos, com opções para segundos e relógio de 12 horas. |
| [Header](https://reference.aspose.com/slides/pt/net/aspose.slides/fieldtype/header/) | Um campo de cabeçalho; veja as limitações de placeholder e formato abaixo. |
| [Footer](https://reference.aspose.com/slides/pt/net/aspose.slides/fieldtype/footer/) | Um campo de rodapé. |

Por exemplo, [DateTime3](https://reference.aspose.com/slides/pt/net/aspose.slides/fieldtype/datetime3/) representa o dia, o nome completo do mês e o ano em inglês. Estes são formatos de campo predefinidos, não strings arbitrárias de formato de data .NET. O [LanguageId](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseportionformat/languageid/) da porção e o aplicativo que processa a apresentação podem afetar o resultado exibido.

## **Criar um Campo a partir de uma String Interna**

A sobrecarga de string de [AddField](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/addfield/) aceita um identificador interno de campo. Use‑a ao preservar um identificador fornecido por outro aplicativo que não possui um valor predefinido. Você também pode construir um [FieldType](https://reference.aspose.com/slides/pt/net/aspose.slides/fieldtype/fieldtype/) a partir do identificador. [IFieldType.InternalString](https://reference.aspose.com/slides/pt/net/aspose.slides/ifieldtype/internalstring/) expõe esse identificador para inspeção.

Este exemplo armazena um campo específico de aplicativo `custom-report-id` com o texto de reserva `Report-042`. O identificador não registra um cálculo: o Aspose.Slides não gera IDs de relatório para um tipo desconhecido. O aplicativo que compreende esse identificador deve fornecer seu significado e atualizar seu valor.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

Após esta ida e volta em PPTX, o tipo é `custom-report-id` e o texto é `Report-042`. Passar uma string como `yyyy-MM-dd` nomearia um tipo de campo; não configuraria um formato de data personalizado. Para uma data fixa em um formato arbitrário, use texto ordinário.

## **Inspecionar, Modificar e Remover Campos de Data/Hora**

Leia e altere um campo existente através de [IField.Type](https://reference.aspose.com/slides/pt/net/aspose.slides/ifield/type/). Verifique se o campo existe antes de acessar seu tipo. Para interromper atualizações automáticas, chame [IPortion.RemoveField](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/removefield/). Isso mantém a porção e seu texto atual enquanto remove a associação ao campo. Se precisar de um valor fixo específico, atribua esse texto após remover o campo.

Para a configuração de API associada ao processamento de campos de data/hora, veja [Presentation.CurrentDateTime](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/currentdatetime/). O exemplo abaixo usa uma data de aprovação explícita ao converter um campo em texto ordinário.

Baixe [sample.pptx](sample.pptx) e coloque‑o no diretório de trabalho. Ele contém duas formas de texto nomeadas, `UpdatedAt` e `ApprovedDate`, cada uma com um campo de data/hora, além de rótulos de texto ordinário. O exemplo a seguir percorre as formas de texto de nível superior em slides regulares. Ele altera campos de data/hora para um formato de data longa e os coloca em itálico, preservando sua outra formatação. Apenas campos em `ApprovedDate` tornam‑se texto fixo.

O exemplo reconhece os identificadores internos incorporados `datetime` e `datetime1` até `datetime13`. Grupos, tabelas, notas, layouts e mestres requerem a travessia de seus próprios contêineres de texto e estão fora do escopo deste exemplo.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

Após reabrir, `UpdatedAt` tem o tipo `datetime3` e permanece dinâmico. `ApprovedDate` não tem campo e contém `05 April 2030`. Ambas as porções de data estão em itálico, e seu tamanho de fonte original, configuração de negrito e cor permanecem intactos. Os rótulos de texto ordinário permanecem inalterados. A verificação lê a primeira porção das duas formas conhecidas no exemplo fornecido.

## **Preservar Formatação de Texto**

Trabalhe com a porção existente ao adicionar um campo, alterar seu tipo ou removê‑lo. Essas operações mantêm a formatação da porção. Use [IPortion.PortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/portionformat/) para mudar apenas as propriedades necessárias, como os exemplos fazem para cor ou itálico.

Evite reconstruir todo um quadro de texto apenas para atualizar um campo: isso pode perder os limites originais das porções e sua formatação individual. Também diferencie formatação definida explicitamente da herdada do parágrafo, layout ou tema. Veja [Text Formatting](/slides/pt/net/text-formatting/) para opções de formatação mais amplas.

## **Campos e Espaços Reservados de Cabeçalho/Rodapé**

Um campo faz parte de uma porção de texto. Um placeholder é uma forma com um papel na apresentação, como rodapé ou número de slide. Adicionar um campo a uma caixa de texto ordinária não transforma essa forma em um placeholder.

Os gerenciadores de cabeçalho/rodapé controlam o texto e a visibilidade dos placeholders em slides, layouts e mestres, incluindo a propagação para slides dependentes. Um campo numérico em uma caixa de texto personalizada pode, portanto, ser útil mesmo quando você não está usando o placeholder de número de slide. Por outro lado, alterar a visibilidade do placeholder não remove um campo de uma caixa de texto não relacionada.

Os tipos predefinidos de cabeçalho e rodapé não criam os placeholders correspondentes nem fornecem seu conteúdo. Em particular, um slide PowerPoint padrão não possui placeholder de cabeçalho; cabeçalhos pertencem a páginas de notas e folhetos. Não presuma que um campo de cabeçalho ou rodapé em uma forma arbitrária obterá automaticamente o texto configurado por um gerente de placeholder. Para esse fluxo de trabalho, veja [Presentation Headers and Footers](/slides/pt/net/presentation-header-and-footer/).

## **Limitações de PPTX e PPT**

Verifique tanto o tipo de campo quanto o texto resultante após salvar e reabrir. Preservar um identificador não prova que um aplicativo pode calcular ou exibir seu valor.

| Formato | Comportamento do campo e limitações |
|---|---|
| PPTX | Armazena identificadores internos de campo junto ao texto do campo. Nos testes de ida e volta, os tipos predefinidos e o identificador customizado usado acima sobreviveram à gravação e reabertura. O tipo customizado desconhecido manteve seu texto de reserva; não adquiriu lógica de cálculo automática. Outro aplicativo pode tratar identificadores não suportados de forma diferente. |
| PPT | Usa representações legadas de campo e tem compatibilidade mais limitada. Nos testes de ida e volta, campos de número de slide e data/hora predefinidos sobreviveram à gravação e reabertura. Um campo customizado em uma caixa de texto de slide ordinário reabriu com seu identificador, mas com `*` como texto; um campo de cabeçalho no mesmo contexto também produziu `*`. Não confie que campos customizados ou contextos de campo não suportados mantenham seu texto visível. |

Para saída portátil e fixa, converta campos não suportados em texto ordinário e atribua explicitamente o valor desejado antes de salvar. Isso preserva o texto escolhido, mas impede atualizações automáticas. Teste também o aplicativo de destino quando sua própria recalculação de campos fizer parte do seu fluxo de trabalho.

## **FAQ**

**Como posso saber se um número ou data exibidos são um campo?**

Verifique [IPortion.Field](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/field/). Um valor não nulo identifica um campo; o texto exibido por si só não pode dizer isso.

**Remover um campo remove seu texto ou formatação?**

Não. [RemoveField](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/removefield/) converte a porção existente em texto ordinário. Atribua um valor explícito depois se precisar de uma data fixa ou texto de reserva específico.

**Uma string interna pode definir um novo formato de data ou fórmula?**

Não. Ela identifica um tipo de campo. Um identificador desconhecido não fornece um avaliador ou um padrão de formato de data .NET. Use um tipo predefinido suportado ou formate o valor você mesmo como texto ordinário.

**Por que verificar uma apresentação novamente após salvá‑la?**

Identificadores de campo, texto calculado e formatação são coisas separadas a serem verificadas. A conversão de formato pode mudar o resultado visível mesmo quando o identificador de campo ainda está presente.