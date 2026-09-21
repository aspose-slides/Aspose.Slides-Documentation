---
title: Gerenciar Campos de Texto em Apresentações PowerPoint em Python
linktitle: Campos de Texto
type: docs
weight: 52
url: /pt/python-net/text-fields/
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
- Aspose.Slides
description: "Crie, inspecione, modifique e remova campos de texto em apresentações PowerPoint com Aspose.Slides para Python via .NET. Preserve a formatação e verifique os arquivos PPTX e PPT salvos."
---
## **Visão geral**

Um parágrafo de texto consiste em porções. Uma [Porção](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/) ordinária contém texto literal; uma porção de campo também tem um [Campo](https://reference.aspose.com/slides/pt/python-net/aspose.slides/field/) cujo tipo identifica um valor atualizado automaticamente, como número do slide ou data. Duas porções podem exibir os mesmos caracteres enquanto apenas uma contém um campo.

Use [Portion.field](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/field/) para distingui‑las: ele é `None` para texto ordinário. [Portion.add_field](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/add_field/) converte uma porção existente em um campo. Mantenha um rótulo e seu valor dinâmico em porções separadas para que a conversão do valor não substitua também o rótulo.

Este guia cobre campos dentro de texto, sua formatação e a gravação em PPTX e PPT. Para quadros de texto e parágrafos, veja [Gerenciar Texto](/slides/pt/python-net/manage-text/).

## **Criar um Campo de Número de Slide**

O exemplo completo a seguir cria uma caixa de texto contendo um rótulo literal `Slide ` seguido por um número atualizado automaticamente. Ele define o tamanho, o peso e a cor do número antes de adicionar o campo, então reabre a apresentação salva e verifica o tipo do campo, o texto e a formatação. Nenhum arquivo de entrada é necessário.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

A nova apresentação começa com o número do slide 1, portanto o texto é `Slide 1`, e ambas as verificações imprimem `True`. O número permanece um campo após a reabertura; não é um literal `1`. Os índices na verificação referem‑se à forma e às porções criadas por este exemplo.

## **Escolher um Tipo de Campo**

[FieldType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fieldtype/) fornece os valores predefinidos a seguir. Passe o valor apropriado para [add_field](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/add_field/).

| Valor | Propósito |
|---|---|
| [slide_number](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fieldtype/slide_number/) | O número do slide atual. |
| [date_time](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fieldtype/date_time/) | Data/hora no formato padrão do aplicativo de renderização. |
| [date_time1](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fieldtype/date_time9/) | Formatos predefinidos de data ou combinações de data/hora. |
| [date_time10](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fieldtype/date_time13/) | Formatos de hora predefinidos, com opções para segundos e relógio de 12 h. |
| [header](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fieldtype/header/) | Um campo de cabeçalho; veja as limitações de marcador de posição e formato abaixo. |
| [footer](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fieldtype/footer/) | Um campo de rodapé. |

Por exemplo, [date_time3](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fieldtype/date_time3/) representa um dia, nome completo do mês e ano em inglês. Esses são formatos de campo predefinidos, não cadeias de formato de data arbitrárias do Python. O [language_id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/language_id/) da porção e o aplicativo que processa a apresentação podem influenciar o resultado exibido.

## **Criar um Campo a partir de uma String Interna**

A sobrecarga de string de [add_field](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/add_field/) aceita um identificador interno de campo. Use‑a ao preservar um identificador fornecido por outro aplicativo que não tem valor predefinido. Você também pode construir um [FieldType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fieldtype/__init__/) a partir do identificador. [FieldType.internal_string](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fieldtype/internal_string/) expõe esse identificador para inspeção.

Este exemplo armazena um campo específico da aplicação `custom-report-id` com o texto de reserva `Report-042`. O identificador não registra um cálculo: Aspose.Slides não gera IDs de relatório para um tipo desconhecido. O aplicativo que entende esse identificador deve fornecer seu significado e atualizar seu valor.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

Após esta ida‑e‑volta em PPTX, o tipo é `custom-report-id` e o texto é `Report-042`. Passar uma string como `%Y-%m-%d` nomearia um tipo de campo; não configuraria um formato de data personalizado. Para uma data fixa em formato arbitrário, use texto ordinário.

## **Inspecionar, Modificar e Remover Campos de Data/Hora**

Leia e altere um campo existente através de [Field.type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/field/type/). Verifique se o campo existe antes de acessar seu tipo. Para interromper atualizações automáticas, chame [Portion.remove_field](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/remove_field/). Isso mantém a porção e seu texto atual enquanto remove a associação ao campo. Se precisar de um valor fixo específico, atribua esse texto após remover o campo.

Para a configuração de API associada ao processamento de campos de data/hora, veja [Presentation.current_date_time](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/current_date_time/). O exemplo abaixo usa uma data de aprovação explícita ao converter um campo em texto ordinário. Uma tupla de nomes de meses em inglês mantém a data fixa independente da localidade do sistema.

Faça download de [sample.pptx](sample.pptx) e coloque‑o no diretório de trabalho. Ele contém duas formas de texto nomeadas, `UpdatedAt` e `ApprovedDate`, cada uma com um campo de data/hora, além de rótulos de texto ordinário. O exemplo a seguir percorre as formas de texto de nível superior em slides regulares. Ele altera campos de data/hora para um formato de data longa e os torna itálicos, preservando sua outra formatação. Apenas os campos em `ApprovedDate` se tornam texto fixo.

O exemplo reconhece os identificadores internos incorporados `datetime` e `datetime1` até `datetime13`. Grupos, tabelas, notas, layouts e mestres exigem a travessia de seus próprios contêineres de texto e estão fora do escopo deste exemplo.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

Após a reabertura, `UpdatedAt` tem o tipo `datetime3` e permanece dinâmico. `ApprovedDate` não tem campo e contém `05 April 2030`. Ambas as porções de data são itálicas, e seu tamanho de fonte original, configuração de negrito e cor permanecem intactos. Os rótulos de texto ordinário permanecem inalterados. A verificação lê a primeira porção das duas formas conhecidas na amostra fornecida.

## **Preservar Formatação de Texto**

Trabalhe com a porção existente ao adicionar um campo, mudar seu tipo ou removê‑lo. Essas operações mantêm a formatação dessa porção. Use [Portion.portion_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/portion_format/) para alterar somente as propriedades necessárias, como nos exemplos para cor ou itálico.

Evite reconstruir um quadro de texto inteiro apenas para atualizar um campo: isso pode perder os limites originais das porções e sua formatação individual. Também distinga formatação definida explicitamente da herdada do parágrafo, layout ou tema. Consulte [Formatação de Texto](/slides/pt/python-net/text-formatting/) para opções de formatação mais amplas.

## **Campos e Marcadores de Posicionamento de Cabeçalho/Rodapé**

Um campo faz parte de uma porção de texto. Um marcador de posição é uma forma com um papel na apresentação, como um rodapé ou número de slide. Adicionar um campo a uma caixa de texto ordinária não transforma essa forma em marcador de posição.

Os gerenciadores de cabeçalho/rodapé controlam o texto e a visibilidade dos marcadores de posição em slides, layouts e mestres, inclusive a propagação para slides dependentes. Um campo de número em uma caixa de texto personalizada pode ser útil mesmo quando você não usa o marcador de posicionamento de número de slide. Por outro lado, mudar a visibilidade do marcador de posição não remove um campo de uma caixa de texto não relacionada.

Os tipos predefinidos de cabeçalho e rodapé não criam os marcadores de posição correspondentes nem fornecem seu conteúdo. Em particular, um slide padrão do PowerPoint não tem marcador de cabeçalho; cabeçalhos pertencem a páginas de notas e folhas de impressão. Não presuma que um campo de cabeçalho ou rodapé em uma forma arbitrária obterá automaticamente o texto configurado por meio de um gerenciador de marcadores de posição. Para esse fluxo de trabalho, veja [Apresentação – Cabeçalhos e Rodapés](/slides/pt/python-net/presentation-header-and-footer/).

## **Limitações do PPTX e PPT**

Verifique tanto o tipo de campo quanto o texto resultante após salvar e reabrir. Preservar um identificador não prova que um aplicativo pode calcular ou exibir seu valor.

| Formato | Comportamento do campo e limitações |
|---|---|
| PPTX | Armazena identificadores internos de campo ao lado do texto do campo. Nos testes de ida‑e‑volta, os tipos predefinidos e o identificador personalizado usado acima sobreviveram à gravação e reabertura. O tipo personalizado desconhecido manteve seu texto de reserva; não adquiriu lógica de cálculo automático. Outro aplicativo pode tratar identificadores não suportados de forma diferente. |
| PPT | Usa representações legadas de campo e tem compatibilidade mais limitada. Nos testes de ida‑e‑volta, campos de número de slide e de data/hora predefinidos sobreviveram à gravação e reabertura. Um campo personalizado em uma caixa de texto de slide ordinário foi reaberto com seu identificador, mas com `*` como texto; um campo de cabeçalho no mesmo contexto também produziu `*`. Não confie que campos personalizados ou contextos de campo não suportados retenham seu texto visível. |

Para saída portátil e fixa, converta campos não suportados em texto ordinário e atribua explicitamente o valor desejado antes de salvar. Isso preserva o texto escolhido, mas interrompe intencionalmente as atualizações automáticas. Teste também o aplicativo de destino quando sua própria recalculação de campo fizer parte do seu fluxo de trabalho.

## **Perguntas Frequentes**

**Como posso saber se um número ou data exibido é um campo?**

Inspecione [Portion.field](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/field/). Um valor diferente de `None` identifica um campo; o texto exibido sozinho não pode dizer isso.

**A remoção de um campo remove seu texto ou formatação?**

Não. [remove_field](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/remove_field/) converte a porção existente em texto ordinário. Atribua um valor explícito depois, se precisar de uma data fixa ou texto de reserva específico.

**Uma string interna pode definir um novo formato de data ou fórmula?**

Não. Ela identifica um tipo de campo. Um identificador desconhecido não fornece um avaliador nem um padrão de formato de data do Python. Use um tipo predefinido suportado ou formate o valor você mesmo como texto ordinário.

**Por que verificar a apresentação novamente após salvá‑la?**

Identificadores de campo, texto calculado e formatação são coisas distintas a serem verificadas. A conversão de formato pode alterar o resultado visível mesmo quando o identificador do campo ainda está presente.