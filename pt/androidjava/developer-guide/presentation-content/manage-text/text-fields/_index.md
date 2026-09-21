---
title: Gerenciar campos de texto em apresentações PowerPoint no Android
linktitle: Campos de Texto
type: docs
weight: 52
url: /pt/androidjava/text-fields/
keywords:
- campo de texto
- texto automático
- número de slide
- data e hora
- cabeçalho
- rodapé
- porção de texto
- PowerPoint
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Criar, inspecionar, modificar e remover campos de texto em apresentações PowerPoint com Aspose.Slides para Android via Java. Preservar a formatação e verificar os arquivos PPTX e PPT salvos."
---
## **Visão geral**

Um parágrafo de texto consiste em porções. Uma [IPortion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/) ordinária contém texto literal; uma porção de campo também tem um [IField](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifield/) cujo tipo identifica um valor atualizado automaticamente, como número de slide ou data. Duas porções podem exibir os mesmos caracteres enquanto apenas uma contém um campo.

Use [IPortion.getField](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/#getField--) para distingui‑las: ele é `null` para texto ordinário. [IPortion.addField](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) converte uma porção existente em um campo. Mantenha um rótulo e seu valor dinâmico em porções separadas para que a conversão do valor não substitua também o rótulo.

Este guia cobre campos dentro de texto, sua formatação e a gravação deles em PPTX e PPT. Para quadros de texto e parágrafos, veja [Manage Text](/slides/pt/androidjava/manage-text/).

## **Criar um Campo de Número de Slide**

O exemplo completo a seguir cria uma caixa de texto contendo um rótulo literal `Slide ` seguido por um número atualizado automaticamente. Ele define o tamanho, peso e cor do número antes de adicionar o campo, depois reabre a apresentação gravada e verifica o tipo do campo, o texto e a formatação. Nenhum arquivo de entrada é necessário.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

A nova apresentação começa com o número de slide 1, portanto o texto é `Slide 1`, e ambas as verificações imprimem `true`. O número permanece um campo após a reabertura; não é um literal `1`. Os casts e índices na verificação referem‑se à forma e às porções criadas por este exemplo.

## **Escolher um Tipo de Campo**

[FieldType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fieldtype/) implementa [IFieldType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifieldtype/) e fornece os métodos a seguir para obter valores predefinidos. Passe o valor apropriado para [addField](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Método | Propósito |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | O número do slide atual. |
| [getDateTime](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | Data/hora no formato padrão do aplicativo de renderização. |
| [getDateTime1](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | Formatos de data ou data/hora combinados predefinidos. |
| [getDateTime10](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | Formatos de hora predefinidos, com opções para segundos e relógio de 12 horas. |
| [getHeader](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fieldtype/#getHeader--) | Um campo de cabeçalho; veja as limitações de placeholder e formato abaixo. |
| [getFooter](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fieldtype/#getFooter--) | Um campo de rodapé. |

Por exemplo, [getDateTime3](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) representa dia, nome completo do mês e ano em inglês. Esses são formatos de campo predefinidos, não strings arbitrárias de formatação de data Java. O idioma definido com [setLanguageId](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) e o aplicativo que processa a apresentação podem influenciar o resultado exibido.

## **Criar um Campo a partir de uma String Interna**

A sobrecarga de string de [addField](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) aceita um identificador de campo interno. Use‑a ao preservar um identificador fornecido por outro aplicativo que não possui valor predefinido. Você também pode construir um [FieldType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) a partir do identificador. [IFieldType.getInternalString](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) expõe esse identificador para inspeção.

Este exemplo armazena um campo específico de aplicação `custom-report-id` com o texto de fallback `Report-042`. O identificador não registra nenhum cálculo: Aspose.Slides não gera IDs de relatório para um tipo desconhecido. O aplicativo que entende esse identificador deve fornecer seu significado e atualizar seu valor.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Depois deste ciclo PPTX, o tipo é `custom-report-id` e o texto é `Report-042`. Passar uma string como `yyyy-MM-dd` nomearia um tipo de campo; não configuraria um formato de data personalizado. Para uma data fixa em um formato arbitrário, use texto ordinário.

## **Inspecionar, Modificar e Remover Campos de Data/Hora**

Altere um campo existente através de [IField.setType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Verifique se o campo existe antes de acessar seu tipo. Para interromper atualizações automáticas, chame [IPortion.removeField](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/#removeField--). Isso mantém a porção e seu texto atual ao remover a associação ao campo. Se precisar de um valor fixo específico, atribua esse texto após remover o campo.

Para a configuração de API associada ao processamento de campos de data/hora, veja [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). O exemplo abaixo usa uma data de aprovação explícita ao converter um campo em texto ordinário.

Baixe [sample.pptx](sample.pptx) e coloque‑o no diretório de trabalho. Ele contém duas formas de texto nomeadas, `UpdatedAt` e `ApprovedDate`, cada uma com um campo de data/hora, além de rótulos de texto ordinário. O exemplo a seguir percorre as formas de texto de nível superior em slides regulares. Ele altera os campos de data/hora para um formato de data longa e os deixa em itálico, preservando sua outra formatação. Apenas os campos em `ApprovedDate` tornam‑se texto fixo.

A amostra reconhece os identificadores internos incorporados `datetime` e `datetime1` até `datetime13`. Grupos, tabelas, notas, layouts e mestres exigem a travessia de seus próprios contêineres de texto e estão fora do escopo deste exemplo.

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Após a reabertura, `UpdatedAt` tem o tipo `datetime3` e permanece dinâmico. `ApprovedDate` não possui campo e contém `05 April 2030`. Ambas as porções de data estão em itálico, e seu tamanho de fonte original, configuração de negrito e cor permanecem intactos. Os rótulos de texto ordinário permanecem inalterados. A verificação lê a primeira porção das duas formas conhecidas na amostra fornecida.

## **Preservar a Formatação de Texto**

Trabalhe com a porção existente ao adicionar um campo, mudar seu tipo ou removê‑lo. Essas operações mantêm a formatação da porção. Use [IPortion.getPortionFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/#getPortionFormat--) para mudar apenas as propriedades necessárias, como nos exemplos para cor ou itálico.

Evite reconstruir um quadro de texto inteiro apenas para atualizar um campo: isso pode perder os limites originais das porções e sua formatação individual. Também distinga formatação definida explicitamente da herdada do parágrafo, layout ou tema. Veja [Text Formatting](/slides/pt/androidjava/text-formatting/) para opções de formatação mais amplas.

## **Campos e Marcadores de Posição de Cabeçalho/Rodapé**

Um campo faz parte de uma porção de texto. Um placeholder é uma forma com um papel na apresentação, como rodapé ou número de slide. Adicionar um campo a uma caixa de texto ordinária não transforma essa forma em um placeholder.

Os gerenciadores de cabeçalho/rodapé controlam o texto e a visibilidade dos placeholders em slides, layouts e mestres, incluindo a propagação para slides dependentes. Um campo numérico em uma caixa de texto personalizada pode ser útil mesmo quando você não está usando o placeholder de número de slide. Por outro lado, alterar a visibilidade de um placeholder não remove um campo de uma caixa de texto não relacionada.

Os tipos predefinidos de cabeçalho e rodapé não criam os placeholders correspondentes nem fornecem seu conteúdo. Em particular, um slide PowerPoint padrão não tem placeholder de cabeçalho; cabeçalhos pertencem a páginas de notas e folhetos. Não presuma que um campo de cabeçalho ou rodapé em uma forma arbitrária obterá automaticamente o texto configurado por um gerenciador de placeholder. Para esse fluxo, veja [Presentation Headers and Footers](/slides/pt/androidjava/presentation-header-and-footer/).

## **Limitações de PPTX e PPT**

Verifique tanto o tipo do campo quanto o texto resultante após salvar e reabrir. Preservar um identificador não prova que um aplicativo possa calcular ou exibir seu valor.

| Formato | Comportamento do campo e limitações |
|---|---|
| PPTX | Armazena identificadores internos de campo juntamente com o texto do campo. Nos testes de ida‑e‑volta, os tipos predefinidos e o identificador personalizado usado acima sobreviveram à gravação e reabertura. O tipo personalizado desconhecido manteve seu texto de fallback; não recebeu lógica de cálculo automática. Outro aplicativo pode tratar identificadores não suportados de forma diferente. |
| PPT | Usa representações legadas de campo e tem compatibilidade mais limitada. Nos testes de ida‑e‑volta, campos de número de slide e de data/hora predefinidos sobreviveram à gravação e reabertura. Um campo personalizado em uma caixa de texto ordinária foi reaberto com seu identificador, mas com `*` como texto; um campo de cabeçalho no mesmo contexto também produziu `*`. Não confie que campos personalizados ou contextos de campo não suportados mantenham seu texto visível. |

Para saída portátil e fixa, converta campos não suportados em texto ordinário e atribua explicitamente o valor desejado antes de salvar. Isso preserva o texto escolhido, mas interrompe intencionalmente as atualizações automáticas. Teste também o aplicativo de destino quando sua própria recalculação de campo fizer parte do seu fluxo de trabalho.

## **Perguntas Frequentes**

**Como posso saber se um número ou data exibido é um campo?**

Inspecione [IPortion.getField](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/#getField--). Um valor não nulo identifica um campo; o texto exibido por si só não pode dizer isso.

**Remover um campo remove seu texto ou formatação?**

Não. [removeField](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/#removeField--) converte a porção existente em texto ordinário. Atribua um valor explícito depois se precisar de uma data fixa ou valor de fallback específico.

**Uma string interna pode definir um novo formato de data ou fórmula?**

Não. Ela apenas identifica um tipo de campo. Um identificador desconhecido não fornece um avaliador nem um padrão de formatação de data Java. Use um tipo predefinido suportado ou formate o valor como texto ordinário.

**Por que verificar a apresentação novamente após salvá‑la?**

Identificadores de campo, texto calculado e formatação são itens separados a serem verificados. A conversão de formato pode alterar o resultado visível mesmo quando o identificador de campo ainda está presente.