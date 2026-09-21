---
title: Gerenciar Campos de Texto em Apresentações PowerPoint em Python via Java
linktitle: Campos de Texto
type: docs
weight: 52
url: /pt/python-java/text-fields/
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
- Python
- Java
- Aspose.Slides
description: "Criar, inspecionar, modificar e remover campos de texto em apresentações PowerPoint com Aspose.Slides para Python via Java. Preservar formatação e verificar arquivos PPTX e PPT salvos."
---
## **Visão geral**

Um parágrafo de texto é composto por porções. Uma [Portion](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/) ordinária contém texto literal; uma porção de campo também possui um [Field](https://reference.aspose.com/slides/pt/python-java/aspose.slides/field/) cujo tipo identifica um valor atualizado automaticamente, como um número de slide ou data. Duas porções podem exibir os mesmos caracteres enquanto apenas uma contém um campo.

Use [Portion.getField](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/#getField) para distinguir them: it is `None` for texto ordinário. [Portion.addField](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/#addField) converte uma porção existente em um campo. Mantenha um rótulo e seu valor dinâmico em porções separadas para que a conversão do valor não substitua também o rótulo.

Este guia aborda campos dentro do texto, sua formatação e a gravação deles em PPTX e PPT. Para quadros de texto e parágrafos, veja [Manage Text](/slides/pt/python-java/manage-text/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```
## **Criar um Campo de Número de Slide**

O exemplo completo abaixo cria uma caixa de texto contendo um rótulo literal `Slide ` seguido por um número atualizado automaticamente. Ele define o tamanho, o peso e a cor do número antes de adicionar o campo, então reabre a apresentação salva e verifica o tipo de campo, o texto e a formatação. Nenhum arquivo de entrada é necessário.

A nova apresentação começa com o número de slide 1, portanto o texto é `Slide 1`, e ambas as verificações exibem `True`. O número permanece um campo após a reabertura; não é um literal `1`. Os índices na verificação referem‑se à forma e às porções criadas por este exemplo.

## **Escolher um Tipo de Campo**

[FieldType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fieldtype/) fornece os seguintes métodos para obter valores predefinidos. Passe o valor apropriado para [addField](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/#addField).

| Método | Propósito |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fieldtype/#getSlideNumber) | O número do slide atual. |
| [getDateTime](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fieldtype/#getDateTime) | Data/hora no formato padrão do aplicativo de renderização. |
| [getDateTime1](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fieldtype/#getDateTime9) | Formatações de data predefinidas ou combinadas de data/hora. |
| [getDateTime10](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fieldtype/#getDateTime13) | Formatações de hora predefinidas, com opções para segundos e relógio de 12 horas. |
| [getHeader](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fieldtype/#getHeader) | Um campo de cabeçalho; veja as limitações de placeholder e formato abaixo. |
| [getFooter](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fieldtype/#getFooter) | Um campo de rodapé. |

Por exemplo, [getDateTime3](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fieldtype/#getDateTime3) representa um dia, o nome completo do mês e o ano em inglês. Estes são formatos de campo predefinidos, não strings arbitrárias de formato de data Python. O idioma definido com [setLanguageId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setLanguageId) e o aplicativo que processa a apresentação podem afetar o resultado exibido.

## **Criar um Campo a partir de uma String Interna**

A sobrecarga de string de [addField](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/#addField) aceita um identificador interno de campo. Use‑a ao preservar um identificador fornecido por outro aplicativo que não possui um valor predefinido. Você também pode construir um [FieldType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fieldtype/#FieldType) a partir do identificador. [FieldType.getInternalString](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fieldtype/#getInternalString) expõe esse identificador para inspeção.

Este exemplo armazena um campo específico de aplicativo `custom-report-id` com o texto de reserva `Report-042`. O identificador não registra um cálculo: Aspose.Slides não gera IDs de relatório para um tipo desconhecido. O aplicativo que entende esse identificador deve fornecer seu significado e atualizar seu valor.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```
Após esta ida e volta do PPTX, o tipo é `custom-report-id` e o texto é `Report-042`. Passar uma string como `yyyy-MM-dd` nomearia um tipo de campo; não configuraria um formato de data personalizado. Para uma data fixa em um formato arbitrário, use texto ordinário.

## **Inspecionar, Modificar e Remover Campos de Data/Hora**

Altere um campo existente através de [Field.setType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/field/#setType). Verifique se o campo existe antes de acessar seu tipo. Para interromper as atualizações automáticas, chame [Portion.removeField](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/#removeField). Isso mantém a porção e seu texto atual ao remover a associação ao campo. Se precisar de um valor fixo específico, atribua esse texto após remover o campo.

Para a configuração de API associada ao processamento de campos de data/hora, veja [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#setCurrentDateTime). O exemplo abaixo usa uma data de aprovação explícita ao converter um campo para texto ordinário.

Faça o download de [sample.pptx](sample.pptx) e coloque‑o no diretório de trabalho. Ele contém duas formas de texto nomeadas, `UpdatedAt` e `ApprovedDate`, cada uma com um campo de data/hora, além de rótulos de texto ordinário. O exemplo a seguir percorre as formas de texto de nível superior em slides regulares. Ele altera os campos de data/hora para um formato de data longa e os torna itálicos, preservando sua outra formatação. Apenas os campos em `ApprovedDate` tornam‑se texto fixo.

A amostra reconhece os identificadores internos internos incorporados `datetime` e `datetime1` até `datetime13`. Grupos, tabelas, notas, layouts e mestres exigem a percorrer seus próprios contêineres de texto e estão fora do escopo deste exemplo.

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # Use nomes de mês em inglês independentemente da localidade do sistema.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```
Após a reabertura, `UpdatedAt` tem o tipo `datetime3` e permanece dinâmico. `ApprovedDate` não tem campo e contém `05 April 2030`. Ambas as porções de data estão em itálico, e seu tamanho de fonte original, configuração de negrito e cor permanecem intactos. Os rótulos de texto ordinário permanecem inalterados. A verificação lê a primeira porção das duas formas conhecidas na amostra fornecida.

## **Preservar Formatação de Texto**

Trabalhe com a porção existente ao adicionar um campo, mudar seu tipo ou removê‑lo. Essas operações mantêm a formatação dessa porção. Use [Portion.getPortionFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/#getPortionFormat) para alterar somente as propriedades necessárias, como os exemplos fazem para cor ou itálico.

Evite reconstruir todo o quadro de texto apenas para atualizar um campo: fazer isso pode perder os limites originais das porções e sua formatação individual. Também diferencie formatação definida explicitamente da herdada do parágrafo, layout ou tema. Veja [Text Formatting](/slides/pt/python-java/text-formatting/) para opções de formatação mais amplas.

## **Campos e Marcadores de Posição de Cabeçalho/Rodapé**

Um campo faz parte de uma porção de texto. Um placeholder é uma forma com um papel na apresentação, como rodapé ou número de slide. Adicionar um campo a uma caixa de texto ordinária não transforma essa forma em um placeholder.

Os gerenciadores de cabeçalho/rodapé controlam o texto do placeholder e sua visibilidade em slides, layouts e mestres, incluindo a propagação para slides dependentes. Um campo numérico em uma caixa de texto personalizada pode, portanto, ser útil mesmo quando você não está usando o placeholder de número de slide. Por outro lado, mudar a visibilidade do placeholder não remove um campo de uma caixa de texto não relacionada.

Os tipos predefinidos de cabeçalho e rodapé não criam os placeholders correspondentes nem fornecem seu conteúdo. Em particular, um slide padrão do PowerPoint não tem placeholder de cabeçalho; cabeçalhos pertencem a páginas de notas e folhetos. Não presuma que um campo de cabeçalho ou rodapé em uma forma arbitrária obterá automaticamente o texto configurado por um gerenciador de placeholder. Para esse fluxo de trabalho, veja [Presentation Headers and Footers](/slides/pt/python-java/presentation-header-and-footer/).

## **Limitações de PPTX e PPT**

Verifique tanto o tipo de campo quanto o texto resultante após salvar e reabrir. Preservar um identificador não comprova que um aplicativo pode calcular ou exibir seu valor.

| Formato | Comportamento do campo e limitações |
|---|---|
| PPTX | Armazena identificadores internos de campo juntamente com o texto do campo. Nos testes de ida‑volta, os tipos predefinidos e o identificador personalizado usado acima sobreviveram à gravação e reabertura. O tipo personalizado desconhecido manteve seu texto de reserva; não adquiriu lógica de cálculo automática. Outro aplicativo pode tratar identificadores não suportados de forma diferente. |
| PPT | Usa representações legadas de campo e tem compatibilidade mais limitada. Nos testes de ida‑volta, campos de número de slide e data/hora predefinidos sobreviveram à gravação e reabertura. Um campo personalizado em uma caixa de texto de slide ordinário reabriu com seu identificador, mas com `*` como texto; um campo de cabeçalho no mesmo contexto também produziu `*`. Não confie que campos personalizados ou contextos de campo não suportados mantenham seu texto visível. |

Para saída portátil e fixa, converta campos não suportados em texto ordinário e atribua explicitamente o valor desejado antes de salvar. Isso preserva o texto escolhido, mas interrompe intencionalmente as atualizações automáticas. Teste também o aplicativo de destino quando sua própria recalculação de campos fizer parte do seu fluxo de trabalho.

## **FAQ**

**Como posso saber se um número ou data exibido é um campo?**

Inspecione [Portion.getField](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/#getField). Um valor diferente de `None` identifica um campo; o texto exibido por si só não pode dizer isso.

**Remover um campo remove seu texto ou formatação?**

Não. [removeField](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/#removeField) converte a porção existente em texto ordinário. Atribua um valor explícito depois se precisar de uma data congelada ou valor de reserva específico.

**Uma string interna pode definir um novo formato de data ou fórmula?**

Não. Ela identifica um tipo de campo. Um identificador desconhecido não fornece um avaliador nem um padrão de formato de data Python. Use um tipo predefinido suportado ou formate o valor você mesmo como texto ordinário.

**Por que verificar uma apresentação novamente após salvá‑la?**

Os identificadores de campo, o texto calculado e a formatação são coisas distintas a serem verificadas. A conversão de formato pode alterar o resultado visível mesmo quando o identificador de campo ainda está presente.