---
title: Aplicar Efeitos de Forma em Apresentações Usando Python via Java
linktitle: Efeito de Forma
type: docs
weight: 30
url: /pt/python-java/shape-effect/
keywords:
- efeito de forma
- efeito de sombra
- efeito de reflexão
- efeito de brilho
- efeito de bordas suaves
- formato de efeito
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Transforme seus arquivos PPT e PPTX com efeitos avançados de forma usando Aspose.Slides para Python via Java — crie slides impressionantes e profissionais em segundos."
---
## **Introdução**

Embora os efeitos no PowerPoint possam ser usados para fazer um formato se destacar, eles diferem de [preenchimentos](/slides/pt/python-java/shape-formatting/#gradient-fill) ou contornos. Usando os efeitos do PowerPoint, você pode criar reflexos convincentes em um formato, espalhar o brilho de um formato, etc.

![Shape effect](shape-effect.png)

O PowerPoint oferece seis efeitos que podem ser aplicados a formatos. Você pode aplicar um ou mais efeitos a um formato.

Algumas combinações de efeitos ficam melhores que outras. Por esse motivo, o PowerPoint oferece opções em **Preset**. As opções de Preset são combinações de dois ou mais efeitos que são conhecidas por produzir bons resultados. Dessa forma, ao selecionar um preset, você não precisará perder tempo testando ou combinando efeitos diferentes para encontrar uma boa combinação.

Aspose.Slides fornece propriedades e métodos na classe [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) que permitem aplicar os mesmos efeitos a formatos em apresentações do PowerPoint.

## **Aplicar um Efeito de Sombra**

Aspose.Slides para Python via Java oferece suporte a sombras externas e internas para formatos. Você pode personalizar a cor, direção, distância e raio de desfoque para combinar com o design da sua apresentação.

### **Aplicar uma Sombra Externa**

Use uma sombra externa para fazer um cartão ou painel se destacar contra o plano de fundo do slide. A sombra se estende além das bordas do formato, criando a impressão de que o formato está elevado acima do slide. Ajuste sua cor, direção, distância e raio de desfoque para combinar com a iluminação e o estilo do seu modelo.

Este código Python mostra como aplicar o [outer shadow effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) a um retângulo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Shadow effect](shadow_effect.png)

### **Aplicar uma Sombra Interna**

Ao reproduzir o estilo visual de um modelo, use uma sombra interna para dar a um cartão ou painel uma aparência recuada. Uma sombra externa se estende fora do formato e o faz parecer elevado, enquanto uma sombra interna sombreia o interior de suas bordas.

Chame [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), então configure a sombra retornada por [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Valores maiores de raio de desfoque produzem bordas mais suaves.

Este exemplo Python cria um cartão azul‑claro com sombra interna cinza‑escura e o salva como um arquivo PPTX. A direção da sombra é 225 graus, sua distância é 7 pontos e seu raio de desfoque é 6 pontos:

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

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Para remover a sombra interna, chame [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) no formato de efeito do formato.

### **Aplicar, Alterar e Remover uma Sombra Predefinida**

Chame [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect), então use [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) para selecionar um [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/). Para mudar de estilo, altere o preset no mesmo formato. Chame [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) para remover a sombra preservando o preenchimento e o contorno.

O exemplo clona o retângulo em cada etapa para que você possa comparar os quatro estados lado a lado em um slide. Ambas as sombras têm deslocamento de 10 pontos. Uma direção de 225° coloca a primeira sombra acima e à esquerda do retângulo. Uma direção de 45° coloca a segunda abaixo e à direita.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetShadowType, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    text_frame = shape.getTextFrame()
    text_frame.setText("No shadow")
    paragraph_format = text_frame.getParagraphs().get_Item(0).getParagraphFormat()
    paragraph_format.getDefaultPortionFormat().setFontHeight(14)
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().enablePresetShadowEffect()
    shadow = shape.getEffectFormat().getPresetShadowEffect()
    shadow.setPreset(PresetShadowType.TopLeftDropShadow)
    shadow.setDistance(10)
    shadow.setDirection(225)
    text_frame.setText("TopLeftDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shadow.setPreset(PresetShadowType.BottomRightDropShadow)
    shadow.setDirection(45)
    text_frame.setText("BottomRightDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().disablePresetShadowEffect()
    text_frame.setText("No shadow")

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Original | Primeiro preset | Segundo preset | Após remoção |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **Aplicar um Efeito de Reflexão**

Para aplicar um efeito de reflexão no Aspose.Slides para Python via Java, você pode adicionar um reflexo semelhante a um espelho nos formatos, ajustando parâmetros como distância, transparência e tamanho. Esse efeito melhora a estética das suas apresentações ao dar aos formatos um visual mais polido e sofisticado. É fácil de implementar com código simples, permitindo aplicação rápida em vários elementos para um design consistente.

Este código Python mostra como aplicar o [reflection effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) a um formato:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Reflection effect](reflection_effect.png)

## **Aplicar um Efeito de Brilho**

Para aplicar um efeito de brilho a um formato no Aspose.Slides para Python via Java, você pode adicionar uma aura suave e luminosa ao redor dos formatos, ajustando propriedades como cor e tamanho. Esse efeito ajuda a destacar os formatos e adiciona um elemento visual atraente à sua apresentação. É fácil de implementar com código mínimo, realçando a aparência geral dos seus slides.

Este código Python mostra como aplicar o [glow effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) a um formato:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Glow effect](glow_effect.png)

## **Aplicar um Efeito de Borda Suave**

Para aplicar um efeito de bordas suaves no Aspose.Slides para Python via Java, você pode criar uma transição lisa e difusa ao redor das bordas de um formato. Esse efeito confere um aspecto mais sutil e refinado, perfeito para designs que requerem uma aparência mais delicada. Você pode ajustar facilmente parâmetros como raio para alcançar o efeito desejado em vários formatos da sua apresentação.

Este código Python mostra como aplicar o [soft edges effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) a um formato:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Soft edges effect](soft_edges_effect.png)

## **Aplicar um Efeito de Desfoque**

Use o desfoque de formato para suavizar o preenchimento e o contorno de um formato mantendo-o editável. Chame [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) no formato de efeito do formato. O raio é medido em pontos (1/72 polegada): use um valor não negativo, com valores maiores produzindo desfoque mais intenso. Um raio zero mantém a aparência inalterada.

A configuração [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) controla os limites visíveis do efeito. Com `False`, o desfoque é recortado aos limites pintados originais, incluindo o contorno. Com `True`, o desfoque pode se estender além desses limites. Nenhuma configuração altera a posição ou as dimensões do formato.

A comparação abaixo usa o mesmo preenchimento, contorno e dimensões do formato em todo o exemplo. A linha superior usa `grow = False`; a linha inferior usa `grow = True`.

![Retângulo original comparado com raios de desfoque de 5 e 15 pontos, com grow desativado e ativado](shape_blur_comparison.png)

Este exemplo Python cria um retângulo laranja com contorno azul‑escuro, aplica um desfoque de 5 pontos e depois o atualiza para 15 pontos chamando [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) novamente. Ele salva ambos os estados desfocados, então chama [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) e salva o formato sem desfoque.

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

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O desfoque de formato afeta o preenchimento e o contorno juntos. Um efeito de bordas suaves esmaece as bordas do formato, enquanto o desfoque de sombra suaviza apenas a sombra. Os efeitos de transformação de imagem operam sobre o conteúdo da imagem; este exemplo aplica desfoque diretamente ao formato de efeito do formato sem converter o formato em imagem.

## **Perguntas Frequentes**

**Posso aplicar múltiplos efeitos ao mesmo formato?**

Sim, você pode combinar diferentes efeitos, como sombra, reflexão e brilho, em um único formato para criar uma aparência mais dinâmica.

**A quais formatos posso aplicar efeitos?**

Você pode aplicar efeitos a diversos formatos, incluindo autoshapes, gráficos, tabelas, imagens, objetos SmartArt, objetos OLE e muito mais.

**Posso aplicar efeitos a formatos agrupados?**

Sim, você pode aplicar efeitos a formatos agrupados. O efeito será aplicado a todo o grupo.