---
title: Gerenciar campos de texto em apresentações PowerPoint em JavaScript
linktitle: Campos de texto
type: docs
weight: 52
url: /pt/nodejs-java/text-fields/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Criar, inspecionar, modificar e remover campos de texto em apresentações PowerPoint com Aspose.Slides para Node.js via Java. Preservar a formatação e verificar arquivos PPTX e PPT salvos."
---
## **Visão geral**

Um parágrafo de texto consiste em portions. Uma [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/) comum contém texto literal; uma portion de campo também possui um [Field](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/field/) cujo tipo identifica um valor atualizado automaticamente, como número do slide ou data. Duas portions podem exibir os mesmos caracteres enquanto apenas uma contém um campo.

Use [Portion.getField](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/#getField) para distingui‑las: ele é `null` para texto comum. [Portion.addField](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/#addField) converte uma portion existente em um campo. Mantenha um rótulo e seu valor dinâmico em portions separadas para que a conversão do valor não substitua também o rótulo.

Este guia aborda campos dentro de texto, sua formatação e a gravação em PPTX e PPT. Para quadros de texto e parágrafos, veja [Manage Text](/slides/pt/nodejs-java/manage-text/).

## **Criar um Campo de Número de Slide**

O exemplo completo a seguir cria uma caixa de texto contendo um rótulo literal `Slide ` seguido por um número atualizado automaticamente. Ele define o tamanho, peso e cor do número antes de adicionar o campo, então reabre a apresentação salva e verifica o tipo do campo, o texto e a formatação. Nenhum arquivo de entrada é necessário.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

A nova apresentação inicia com o número de slide 1, portanto o texto é `Slide 1`, e ambas as verificações imprimem `true`. O número permanece um campo após a reabertura; não é um literal `1`. Os índices na verificação referem‑se à forma e às portions criadas por este exemplo.

## **Escolher um Tipo de Campo**

[FieldType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fieldtype/) fornece os seguintes métodos para obter valores predefinidos. Passe o valor apropriado para [addField](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/#addField).

| Method | Purpose |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | O número atual do slide. |
| [getDateTime](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fieldtype/#getDateTime) | Data/hora no formato padrão da aplicação de renderização. |
| [getDateTime1](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | Formatos de data ou combinações de data/hora predefinidos. |
| [getDateTime10](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | Formatos de hora predefinidos, com opções para segundos e relógio de 12 horas. |
| [getHeader](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fieldtype/#getHeader) | Um campo de cabeçalho; veja as limitações de marcador de posição e formato abaixo. |
| [getFooter](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fieldtype/#getFooter) | Um campo de rodapé. |

Por exemplo, [getDateTime3](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fieldtype/#getDateTime3) representa dia, nome completo do mês e ano em inglês. Estes são formatos de campo predefinidos, não cadeias arbitrárias de formatação de data. O idioma definido com [setLanguageId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) e a aplicação que processa a apresentação podem afetar o resultado exibido.

## **Criar um Campo a partir de uma String Interna**

A sobrecarga de string de [addField](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/#addField) aceita um identificador interno de campo. Use‑a quando for preciso preservar um identificador fornecido por outra aplicação que não possui valor predefinido. Você também pode construir um [FieldType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fieldtype/) a partir do identificador. [FieldType.getInternalString](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fieldtype/#getInternalString) expõe esse identificador para inspeção.

Este exemplo armazena um campo específico de aplicação `custom-report-id` com o texto de fallback `Report-042`. O identificador não registra um cálculo: Aspose.Slides não gera IDs de relatório para um tipo desconhecido. A aplicação que entende esse identificador deve fornecer seu significado e atualizar seu valor.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Após esta ida e volta em PPTX, o tipo é `custom-report-id` e o texto é `Report-042`. Passar uma string como `yyyy-MM-dd` nomearia um tipo de campo; não configuraria um formato de data personalizado. Para uma data fixa em formato arbitrário, use texto comum.

## **Inspecionar, Modificar e Remover Campos de Data/Hora**

Altere um campo existente através de [Field.setType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/field/#setType). Verifique se o campo existe antes de acessar seu tipo. Para interromper atualizações automáticas, chame [Portion.removeField](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/#removeField). Isso mantém a portion e seu texto atual enquanto remove a associação ao campo. Se precisar de um valor fixo específico, atribua esse texto após remover o campo.

Para a configuração de API associada ao processamento de campos de data/hora, veja [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#setCurrentDateTime). O exemplo abaixo usa uma data de aprovação explícita ao converter um campo para texto comum.

Baixe [sample.pptx](sample.pptx) e coloque‑o no diretório de trabalho. Ele contém duas formas de texto nomeadas, `UpdatedAt` e `ApprovedDate`, cada uma com um campo de data/hora, além de rótulos de texto comuns. O exemplo a seguir percorre as formas de texto de nível superior em slides regulares. Ele altera campos de data/hora para um formato de data longa e os deixa em itálico, preservando a outra formatação. Apenas os campos em `ApprovedDate` tornam‑se texto fixo.

O índice de mês do JavaScript começa em zero, portanto abril corresponde a `3`. UTC é usado tanto na construção quanto na formatação para manter a data independente do fuso horário local.

A amostra reconhece os identificadores internos incorporados `datetime` e `datetime1` a `datetime13`. Grupos, tabelas, notas, layouts e mestres exigem percorrer seus próprios contêineres de texto e estão fora do escopo deste exemplo.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Após a reabertura, `UpdatedAt` tem o tipo `datetime3` e permanece dinâmico. `ApprovedDate` não tem campo e contém `05 April 2030`. Ambas as portions de data estão em itálico, e seu tamanho de fonte original, configuração de negrito e cor permanecem intactos. Os rótulos de texto comuns ficam inalterados. A verificação lê a primeira portion das duas formas conhecidas no exemplo fornecido.

## **Preservar Formatação de Texto**

Trabalhe com a portion existente ao adicionar um campo, mudar seu tipo ou removê‑lo. Essas operações mantêm a formatação dessa portion. Use [Portion.getPortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/#getPortionFormat) para alterar apenas as propriedades necessárias, como os exemplos fazem para cor ou itálico.

Evite reconstruir todo o quadro de texto apenas para atualizar um campo: isso pode perder os limites originais das portions e sua formatação individual. Também distinga formatação definida explicitamente da herdada do parágrafo, layout ou tema. Consulte [Text Formatting](/slides/pt/nodejs-java/text-formatting/) para opções de formatação mais amplas.

## **Campos e Marcadores de Posição de Cabeçalho/Rodapé**

Um campo faz parte de uma portion de texto. Um marcador de posição é uma forma com um papel na apresentação, como rodapé ou número de slide. Adicionar um campo a uma caixa de texto comum não transforma essa forma em marcador de posição.

Os gerenciadores de cabeçalho/rodapé controlam o texto do marcador de posição e sua visibilidade em slides, layouts e mestres, inclusive a propagação para slides dependentes. Um campo numérico em uma caixa de texto personalizada pode, portanto, ser útil mesmo quando você não usa o marcador de posição de número de slide. Por outro lado, alterar a visibilidade do marcador de posição não remove um campo de uma caixa de texto não relacionada.

Os tipos predefinidos de cabeçalho e rodapé não criam os marcadores de posição correspondentes nem fornecem seu conteúdo. Em particular, um slide PowerPoint regular não possui marcador de posição de cabeçalho; cabeçalhos pertencem a páginas de notas e folhetos. Não presuma que um campo de cabeçalho ou rodapé em uma forma arbitrária obterá automaticamente o texto configurado via gerenciador de marcadores de posição. Para esse fluxo, veja [Presentation Headers and Footers](/slides/pt/nodejs-java/presentation-header-and-footer/).

## **Limitações do PPTX e PPT**

Verifique tanto o tipo do campo quanto o texto resultante após salvar e reabrir. Preservar um identificador não prova que uma aplicação pode calcular ou exibir seu valor.

| Format | Field behavior and limitations |
|---|---|
| PPTX | Armazena identificadores internos de campo ao lado do texto do campo. Nos testes de ida e volta, os tipos predefinidos e o identificador personalizado usado acima sobreviveram à gravação e reabertura. O tipo personalizado desconhecido manteve seu texto de fallback; não adquiriu lógica de cálculo automática. Outra aplicação pode tratar identificadores não suportados de forma diferente. |
| PPT | Usa representações legadas de campo e tem compatibilidade mais limitada. Nos testes de ida e volta, campos de número de slide e de data/hora predefinidos sobreviveram à gravação e reabertura. Um campo personalizado em uma caixa de texto de slide comum reabriu com seu identificador, porém com `*` como texto; um campo de cabeçalho no mesmo contexto também produziu `*`. Não dependa de campos personalizados ou contextos de campo não suportados mantendo seu texto visível. |

Para saída portátil e fixa, converta campos não suportados em texto comum e atribua explicitamente o valor desejado antes de salvar. Isso preserva o texto escolhido, mas interrompe intencionalmente as atualizações automáticas. Teste também a aplicação de destino quando sua própria recalculação de campo faz parte do seu fluxo de trabalho.

## **FAQ**

**Como posso saber se um número ou data exibido é um campo?**

Inspecione [Portion.getField](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/#getField). Um valor não nulo identifica um campo; o texto exibido sozinho não pode dizer isso.

**A remoção de um campo remove seu texto ou formatação?**

Não. [removeField](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/#removeField) converte a portion existente em texto comum. Atribua um valor explícito depois, se precisar de uma data fixa ou valor de fallback.

**Uma string interna pode definir um novo formato de data ou fórmula?**

Não. Ela identifica um tipo de campo. Um identificador desconhecido não fornece um avaliador ou padrão de formatação de data. Use um tipo predefinido suportado ou formate o valor você mesmo como texto comum.

**Por que verificar a apresentação novamente após salvá‑la?**

Identificadores de campo, texto calculado e formatação são coisas separadas a serem verificadas. A conversão de formato pode mudar o resultado visível mesmo quando o identificador do campo ainda está presente.