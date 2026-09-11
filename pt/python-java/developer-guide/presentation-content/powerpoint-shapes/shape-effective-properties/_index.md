---
title: Obter Propriedades Efetivas de Forma de Apresentações em Python via Java
linktitle: Propriedades Efetivas
type: docs
weight: 50
url: /pt/python-java/shape-effective-properties/
keywords:
- propriedades de forma
- propriedades de câmera
- sistema de iluminação
- forma chanfrada
- quadro de texto
- estilo de texto
- altura da fonte
- formato de preenchimento
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda a usar Aspose.Slides para Python via Java para distinguir a formatação local, herdada e efetiva de formas em apresentações do PowerPoint."
---
## **Entender Propriedades Locais, Herdadas e Efetivas**

O formato do PowerPoint pode vir de vários lugares. O valor armazenado diretamente em um objeto é seu **valor local**. Se esse valor não estiver definido, o PowerPoint procura nas fontes de formatação pai, como o padrão de parágrafo, um estilo de texto, um layout ou slide mestre, um tema ou padrões ao nível da apresentação. Esses valores são **valores herdados**. O valor que resta após toda a hierarquia ser resolvida é o **valor efetivo** — o valor usado para renderizar o objeto.

Por exemplo, uma porção de texto pode não definir sua própria altura de fonte. Seu valor local [getFontHeight](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#getFontHeight) passa a ser `float("nan")`, que significa "não definido aqui". A porção pode herdar uma altura do seu parágrafo, do estilo de texto padrão da apresentação ou de outra fonte aplicável. Chamar [getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/#getEffective) no formato da porção retorna a altura final resolvida.

Use os dois tipos de dados de formatação para diferentes propósitos:

- Leia ou altere um objeto de formato local, como [PortionFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/), quando precisar controlar onde um valor é definido.
- Leia um objeto de dados efetivo, como `PortionFormatEffectiveData`, quando precisar do resultado final renderizado. Dados efetivos são somente leitura.

## **Comparar Valores Locais, Herdados e Efetivos**

O exemplo completo a seguir cria uma forma e aplica alturas de fonte nos níveis de apresentação, parágrafo e porção. Cada etapa imprime os valores definidos nesses níveis e o valor efetivo resultante para a mesma porção de texto. Também demonstra por que os dados efetivos precisam ser lidos novamente após alterações de formatação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # Leia os dados efetivos após as alterações anteriores.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # Defina valores herdados em dois níveis diferentes.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Um valor local na porção substitui ambos os valores herdados.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Alterar um valor herdado não substitui um valor local existente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Limpe o valor local. A porção agora herda novamente do parágrafo.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Limpe o valor do parágrafo. O padrão da apresentação agora fornece o resultado.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A prioridade neste exemplo é a formatação local da porção, depois a formatação do parágrafo e, por fim, o padrão da apresentação. Outros objetos podem ter cadeias de herança diferentes, mas o princípio é o mesmo: um valor explícito mais específico prevalece, e [getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/#getEffective) retorna o resultado final.

## **Obter Propriedades de Texto Efetivas**

A formatação de texto está dividida entre vários objetos:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#getEffective) resolve as propriedades de quadro de texto, como margens, ancoragem, ajuste automático e direção vertical do texto.
- [TextStyle.getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textstyle/#getEffective) resolve a formatação de parágrafo para cada nível de estilo de texto.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraphformat/#getEffective) resolve as propriedades de parágrafo, como alinhamento, recuo e marcadores.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/#getEffective) resolve as propriedades de caractere, como altura de fonte, tipo de letra, cor, negrito e itálico.

Para o próximo exemplo, `text-formatting.pptx` deve conter ao menos um slide e uma [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) com um quadro de texto não vazio. A AutoShape pode aparecer em qualquer posição na coleção de formas; o código procura um objeto adequado e o valida antes do uso.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **Obter Propriedades 3D Efetivas**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#getEffective) retorna um objeto `ThreeDFormatEffectiveData` que agrupa todas as configurações 3D resolvidas. Seus métodos `getCamera`, `getLightRig`, `getBevelTop` e `getBevelBottom` expõem os dados efetivos correspondentes. Ler essas configurações relacionadas juntas facilita a compreensão da aparência 3D final de uma forma.

Para este exemplo, `shape-3d.pptx` deve conter ao menos uma forma no primeiro slide. Aplique configurações de câmera 3D, iluminação ou chanfradura a essa forma se quiser que a saída contenha valores diferentes dos padrões.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **Obter Formatação de Tabela Efetiva**

A formatação de tabela pode vir do estilo de tabela e de formatos aplicados à tabela inteira, a uma coluna, a uma linha ou a uma célula individual. Em conflitos entre preenchimentos definidos explicitamente, a prioridade é célula, linha, coluna e, então, tabela inteira. O formato efetivo de uma célula é o formato final usado para desenhar essa célula.

Para este exemplo, `table-formatting.pptx` deve conter ao menos uma tabela no primeiro slide. A tabela deve ter ao menos uma linha e uma coluna. O código procura por uma [Table](https://reference.aspose.com/slides/pt/python-java/aspose.slides/table/) ao invés de assumir que `getShapes().get_Item(0)` é uma tabela.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

Se precisar da cor em vez de apenas o tipo de preenchimento, primeiro verifique o `getFillType` efetivo e, em seguida, leia o método que se aplica a esse tipo — por exemplo, `getSolidFillColor` para um preenchimento sólido.

## **Reler Dados Efetivos Após Alterações**

Dados efetivos descrevem a hierarquia de formatação no momento em que são resolvidos. Chame [getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/#getEffective) novamente após alterar qualquer coisa que possa participar dessa hierarquia, incluindo:

- a formatação local do objeto;
- padrões de parágrafo ou de quadro de texto;
- um estilo de tabela, tabela, coluna, linha ou formato de célula;
- formatação de layout ou slide mestre;
- dados de tema ou padrões ao nível da apresentação;
- o layout ou mestre atribuído a um slide.

Não mantenha um objeto de dados efetivo como um instantâneo permanente. Aspose.Slides pode armazenar em cache alguns dados efetivos internamente, e uma chamada posterior a [getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/#getEffective) pode atualizar esses dados. Se precisar comparar valores antes e depois de uma alteração, copie os valores escalares que precisar — como altura de fonte, cor, alinhamento ou largura da chanfradura — para suas próprias variáveis antes de fazer a mudança.

Para mudar um valor, atualize o objeto de formato local apropriado e então chame [getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/#getEffective) para verificar o resultado. Os próprios objetos de dados efetivos são somente leitura.

## **FAQ**

**Como posso saber qual nível forneceu um valor efetivo?**

Os dados efetivos contêm o valor final, não sua origem. Inspecione os objetos locais aplicáveis do nível mais específico para fora. Para texto, isso pode incluir a porção, parágrafo, quadro de texto, layout, mestre, tema e padrões da apresentação. Valores indefinidos como `float("nan")` ou `None` indicam que a busca continua para outro nível.

**O que acontece quando nenhum nível define uma propriedade?**

Aspose.Slides resolve o padrão apropriado do PowerPoint ou da biblioteca. Esse valor resolvido aparece nos dados efetivos mesmo que nenhum objeto local o defina explicitamente.

**Por que um valor efetivo às vezes é igual ao valor local?**

O valor local venceu o cálculo de herança. Isso é esperado quando a propriedade está explicitamente definida no objeto e nenhuma regra mais específica a substitui.

**Quando devo usar dados locais em vez de dados efetivos?**

Use dados locais para inspecionar ou editar um nível específico de formatação. Use dados efetivos quando precisar da aparência final após herança, regras de tema e estilos aplicáveis serem resolvidos. O [exemplo completo de comparação](#compare-local-inherited-and-effective-values) demonstra ambos no mesmo fluxo de trabalho.