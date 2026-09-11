---
title: Gerenciar Formas de Apresentação em Python via Java
linktitle: Manipulação de Formas
type: docs
weight: 40
url: /pt/python-java/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma de apresentação
- Forma no slide
- Encontrar forma
- Clonar forma
- Remover forma
- Ocultar forma
- Alterar ordem da forma
- Obter ID de forma interop
- Texto alternativo da forma
- Ponto de ajuste da forma
- Ajuste de forma predefinido
- Geometria da forma
- Formatos de layout da forma
- Forma como SVG
- Forma para SVG
- Alinhar forma
- Inverter forma
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda a identificar, ajustar, clonar, remover, ocultar, reordenar, exportar, alinhar e inverter formas de apresentação com Aspose.Slides para Python via Java."
---
## **Visão geral**

Aspose.Slides for Python via Java representa as formas em um slide como um [ShapeCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/) ordenado. A coleção é tanto o local onde você encontra e modifica formas quanto a fonte da ordem de empilhamento: o índice `0` é a forma mais ao fundo, enquanto o último índice é a forma mais à frente.

Este artigo segue esse modelo. Primeiro explica como identificar uma forma de forma confiável e modificar pontos de ajuste de forma predefinidos, depois mostra como clonar, remover, ocultar e reordenar formas. As seções finais cobrem formatação em nível de layout, exportação SVG, alinhamento e configurações de inversão. Cada exemplo é independente, de modo que você pode usar apenas as operações necessárias ao seu fluxo de trabalho.

## **Identificar e Encontrar Formas**

Os índices da coleção são convenientes ao processar um arquivo conhecido, mas não são identificadores estáveis. Adicionar, remover ou reordenar uma forma pode mudar seu índice. Escolha um identificador de acordo com a forma como a apresentação é criada e mantida:

- [Name](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getName) é útil para modelos controlados por desenvolvedores e é fácil de inspecionar no Painel de Seleção do PowerPoint. Nomes podem ser editados e não são garantidos como únicos, portanto estabeleça uma convenção de nomenclatura se o código depender deles.
- [AlternativeText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getAlternativeText) é útil quando uma descrição de acessibilidade ou uma tag fornecida pelo autor já identifica a forma. É visível aos usuários, pode ser localizado ou reescrito para acessibilidade e não é garantido como único. Não reutilize silenciosamente texto de acessibilidade significativo como chave de banco de dados.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getOfficeInteropShapeId) é um identificador somente leitura que é único dentro de um slide e corresponde ao ID de forma usado pelo interop do PowerPoint. Use-o ao integrar com o PowerPoint ou quando precisar de uma referência inequívoca durante a vida útil de uma forma. Uma forma clonada ou recriada é uma forma diferente e recebe seu próprio ID.

O método relacionado [getUniqueId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getUniqueId) retorna um identificador com escopo de apresentação, mas esse identificador é destinado a complementos e pode ser reatribuído. Não deve ser tratado como uma chave externa permanente. Se a identidade a longo prazo for essencial, mantenha o mapeamento em dados de aplicação e valide se a forma esperada ainda existe.

O exemplo a seguir procura por nome com comparação exata e relata o ID de interop com escopo de slide. Quando o modelo não contém a forma esperada, o código relata esse resultado em vez de continuar com o objeto errado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

Quando uma operação é específica a um tipo de forma, verifique o tipo antes de usar membros específicos. Este exemplo atualiza texto e texto alternativo apenas se o objeto nomeado for um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **Identificar e Modificar Ajustes de Forma Predefinidos**

Formas de geometria predefinida podem expor pontos de ajuste que controlam recursos como tamanho de cantos, proporções de setas ou ângulos de arcos. Acesse-os por meio da coleção somente leitura [GeometryShape.getAdjustments](https://reference.aspose.com/slides/pt/python-java/aspose.slides/geometryshape/#getAdjustments). A própria coleção é fornecida pela forma, mas cada [AdjustValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/) contém um valor que pode ser alterado.

Não dependa apenas de um índice de coleção fixo. Percorra os ajustes e inspecione o método somente leitura [getType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getType), cujo valor [ShapeAdjustmentType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeadjustmenttype/) descreve o que o ajuste controla. O método somente leitura [getName](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getName) fornece informações adicionais de identificação e é especialmente útil quando um predefinido contém mais de um ajuste com o mesmo tipo semântico.

Use o método de valor que corresponde ao significado do ajuste:

| Tipo de Ajuste | Propósito | Valor a alterar |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | Tamanho dos cantos arredondados | [setRawValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | Espessura da cauda da seta | [setRawValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | Comprimento da cabeça da seta | [setRawValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | Largura da cabeça da seta | [setRawValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | Ângulo inicial de um setor ou arco | [setAngleValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | Ângulo final de um setor ou arco | [setAngleValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getType) e [getName](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getName) retornam informações somente leitura. [getRawValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getRawValue) e [setRawValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#setRawValue) trabalham com um inteiro nas unidades nativas da geometria do predefinido, enquanto [getAngleValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getAngleValue) e [setAngleValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#setAngleValue) trabalham com um ângulo em graus. O número, ordem, significado e intervalo válido dos ajustes dependem do predefinido [ShapeType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/geometryshape/#getShapeType). Um valor válido para um predefinido pode ser inválido ou ter efeito diferente para outro.

Quando [getType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getType) retorna [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeadjustmenttype/#Custom), a API não reconhece um significado semântico padrão. Inspecione [getName](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getName), o tipo do predefinido e o valor existente, e deixe o ajuste inalterado a menos que o significado e intervalo esperados sejam conhecidos. Mesmo para tipos reconhecidos, verifique se o mesmo tipo ocorre mais de uma vez antes de selecionar um valor. O artigo [Connector](/slides/pt/python-java/connector/) mostra essa situação com ajustes de curvatura de conector.

O exemplo completo a seguir cria versões padrão e modificadas de três formas predefinidas. Ele itera por cada ajuste, relata seu nome e tipo, altera valores relacionados ao tamanho através de [setRawValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#setRawValue), altera ângulos através de [setAngleValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#setAngleValue) e salva o resultado. A coluna esquerda mantém a geometria padrão; a coluna direita mostra o retângulo arredondado ajustado, a seta de quatro pontas e o setor.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Adiciona cabeçalhos para as colunas de forma padrão e ajustada.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Verificar o tipo semântico antes de mudar um valor torna o código explícito quanto à sua intenção e evita supor que um índice de coleção específico tem o mesmo significado em diferentes formas predefinidas.

## **Modificar a Coleção de Formas**

Os métodos add, clone, remove e reorder operam na coleção imediatamente. Se uma operação altera o número ou a ordem das formas, não continue a confiar em índices capturados antes dessa operação.

### **Clonar uma Forma**

[addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addClone) cria uma cópia independente e a anexa à coleção de destino. [insertClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#insertClone) também cria uma cópia, mas a coloca em um índice z‑order especificado. As sobrecargas que aceitam coordenadas movem a clonagem sem alterar seu tamanho; sobrecargas com largura e altura podem redimensioná‑la também.

O exemplo cria um slide de destino, clona um retângulo rotulado para a frente e insere um segundo clone na parte de trás. Alterações em qualquer clone não modificam a forma original.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Clonar copia o conteúdo e a formatação da forma, incluindo seu nome e texto alternativo. Atribua novos identificadores lógicos ao clone quando esses valores precisarem ser únicos. Recursos usados por formas complexas são tratados pela apresentação, mas um clone permanece como um novo item da coleção com uma nova identidade de forma.

### **Remover Formas**

[remove](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#remove) exclui um objeto forma específico de sua coleção. Ao remover múltiplas correspondências durante iteração indexada, percorra do final para que cada índice restante continue válido.

Este exemplo remove cada forma com um nome designado. Ele lê a forma no índice atual, não um item de coleção fixo, e não faz casting desnecessário da forma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Após a remoção, a contagem de formas e os índices das formas posteriores mudam. Referências a formas não afetadas permanecem mais confiáveis que índices salvos. Também considere conectores, animações e outros recursos da apresentação que podem referir‑se ao objeto removido; remover uma forma visível pode mudar mais do que a aparência do slide.

### **Ocultar uma Forma**

Definir [Hidden](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#setHidden) como `True` mantém a forma na coleção, mas impede que ela apareça na apresentação normal. Seu índice, formatação e conteúdo permanecem disponíveis ao código, de modo que ocultar é apropriado para elementos opcionais que podem ser restaurados posteriormente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ocultar não é exclusão nem segurança. O objeto ainda pode ser descoberto e desocultado por um usuário ou por código, e continua parte do arquivo da apresentação.

### **Alterar a Ordem Z**

Formas sobrepostas são pintadas na ordem da coleção. [reorder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#reorder) move uma forma existente para um índice alvo sem cloná‑la. O índice `0` está atrás; o [size](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#size) da coleção menos um está à frente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O retângulo é criado primeiro e inicialmente fica atrás da elipse. Movê‑lo para o índice final coloca‑o à frente. Finalize a ordem Z após adicionar ou clonar todas as formas relacionadas, pois essas operações anexam ou inserem novos itens na coleção e podem alterar a pilha pretendida.

## **Inspecionar Formas em Slides de Layout**

Slides normais, slides de layout e slides mestre têm coleções de formas separadas. Uma forma na coleção de layout não é o mesmo objeto que uma forma posicionada de forma semelhante em um slide normal. Inspecione as formas de layout quando precisar entender ou mudar a formatação fornecida por um layout.

O exemplo a seguir lê o [FillFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getFillFormat) e o [LineFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getLineFormat) de cada forma de layout sem assumir que toda forma seja um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

Editar um layout pode afetar vários slides que o utilizam. Antes de mudar uma forma de layout, determine se um slide normal herda o objeto ou contém uma sobrescrita local, e teste cada slide que usa esse layout.

## **Exportar uma Forma para SVG**

O método `writeAsSvg` de [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/) grava o conteúdo renderizado de uma forma em um fluxo. O resultado contém a forma, não o fundo inteiro do slide nem formas vizinhas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Mantenha a apresentação aberta durante a renderização. A saída depende da formatação da forma e de recursos como fontes e imagens. Se precisar de toda a composição, exporte o slide em vez de uma forma individual. O chamador possui o fluxo e deve fechá‑lo.

## **Alinhar Formas**

Os overloads de [SlideUtil.alignShapes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideutil/#alignShapes) alinham todas as formas ou índices de coleção selecionados. [ShapesAlignmentType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapesalignmenttype/) especifica a borda, linha central ou modo de distribuição. Defina `align_to_slide` como `True` para usar as bordas do slide; defina como `False` para alinhar as formas selecionadas entre si.

Este exemplo alinha três formas à borda superior do slide. As referências de forma retornadas são convertidas para seus índices atuais imediatamente antes do alinhamento.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Alinhamento altera posições, não a ordem Z. Alinhamento relativo normalmente requer ao menos duas formas, enquanto distribuição horizontal ou vertical precisa de formas suficientes para definir espaçamento. Recalcule os índices se modificar a coleção antes de chamar o método.

## **Inverter uma Forma**

A classe [ShapeFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeframe/) armazena posição, tamanho, configurações de inversão horizontal e vertical e rotação. Seus valores [getFlipH](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeframe/#getFlipH) e [getFlipV](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeframe/#getFlipV) utilizam [NullableBool](https://reference.aspose.com/slides/pt/python-java/aspose.slides/nullablebool/): `True` habilita a inversão, `False` a desabilita e `NotDefined` preserva o estado não especificado/padrão.

A apresentação de entrada abaixo contém uma forma não invertida.

![A forma antes de inverter](shape_to_be_flipped.png)

O exemplo preserva todos os demais valores de frame e substitui apenas as duas configurações de inversão. Isso é importante porque atribuir um novo [Frame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#setFrame) substitui o frame completo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A forma salva está espelhada horizontal e verticalmente, mantendo sua posição, tamanho e rotação.

![A forma após inverter](flipped_shape.png)

## **FAQ**

**Devo usar um índice de coleção como identificador de forma?**

Somente para processamento de curta duração, quando a coleção não mudará antes do uso do índice. Prefira um [Name](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getName) ou [AlternativeText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getAlternativeText) validado para modelos criados, ou [OfficeInteropShapeId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getOfficeInteropShapeId) para trabalho de interop de slide.

**Ocultar uma forma a remove da ordem Z?**

Não. Uma forma oculta permanece na coleção no mesmo índice. Ela pode ser encontrada, reordenada, editada ou tornada visível novamente.

**Por que uma forma clonada apareceu à frente de outra forma?**

[addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addClone) anexa o clone ao final da coleção, que é a frente da ordem Z. Use [insertClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#insertClone) para escolher o índice inicial ou [reorder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#reorder) depois que todas as formas foram adicionadas.

**Posso usar um índice fixo para identificar um ajuste de forma predefinido?**

Somente após validar o predefinido exato e o layout da coleção. Prefira iterar por [GeometryShape.getAdjustments](https://reference.aspose.com/slides/pt/python-java/aspose.slides/geometryshape/#getAdjustments) e verificar [AdjustValue.getType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getType); use [AdjustValue.getName](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getName) como informação adicional quando o mesmo tipo semântico aparecer mais de uma vez.