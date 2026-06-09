---
title: Gerenciar Fundos de Apresentação em Python
linktitle: Fundo do Slide
type: docs
weight: 20
url: /pt/python-net/presentation-background/
keywords:
- fundo de apresentação
- fundo do slide
- cor sólida
- cor gradiente
- fundo de imagem
- transparência do fundo
- propriedades do fundo
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a definir fundos dinâmicos em arquivos PowerPoint e OpenDocument usando Aspose.Slides para Python via .NET, com dicas de código para aprimorar suas apresentações."
---
## **Introdução**

Cores sólidas, gradientes e imagens são comumente usados como fundos de slides. Você pode definir o fundo para um **slide normal** (um único slide) ou um **slide mestre** (aplica‑se a vários slides de uma vez).

![PowerPoint background](powerpoint-background.png)

## **Definir um Fundo de Cor Sólida para um Slide Normal**

Aspose.Slides permite definir uma cor sólida como fundo para um slide específico em uma apresentação, mesmo que a apresentação use um slide mestre. A alteração se aplica somente ao slide selecionado.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/backgroundtype/) do slide como `OWN_BACKGROUND`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) de fundo do slide como `SOLID`.
4. Use a propriedade `solid_fill_color` em [FillFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fillformat/) para especificar a cor de fundo sólida.
5. Salve a apresentação modificada.

O exemplo Python a seguir mostra como definir uma cor sólida azul como fundo de um slide normal:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crie uma instância da classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Defina a cor de fundo do slide como azul.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Salve a apresentação no disco.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir um Fundo de Cor Sólida para o Slide Mestre**

Aspose.Slides permite definir uma cor sólida como fundo do slide mestre em uma apresentação. O slide mestre funciona como um modelo que controla a formatação de todos os slides, portanto, ao escolher uma cor sólida para o fundo do slide mestre, ela será aplicada a todos os slides.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/backgroundtype/) do slide mestre (via `masters`) como `OWN_BACKGROUND`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) de fundo do slide mestre como `SOLID`.
4. Use a propriedade `solid_fill_color` em [FillFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fillformat/) para especificar a cor de fundo sólida.
5. Salve a apresentação modificada.

O exemplo Python a seguir mostra como definir uma cor sólida (verde floresta) como fundo de um slide mestre:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crie uma instância da classe Presentation.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Defina a cor de fundo do slide Mestre como Verde Floresta.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Salve a apresentação no disco.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir um Fundo Gradiente para um Slide**

Um gradiente é um efeito gráfico criado por uma mudança gradual de cor. Quando usado como fundo de slide, gradientes podem tornar as apresentações mais artísticas e profissionais. Aspose.Slides permite definir uma cor gradiente como fundo dos slides.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/backgroundtype/) do slide como `OWN_BACKGROUND`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) de fundo do slide como `GRADIENT`.
4. Use a propriedade `gradient_format` em [FillFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fillformat/) para configurar as definições de gradiente desejadas.
5. Salve a apresentação modificada.

O exemplo Python a seguir mostra como definir uma cor gradiente como fundo de um slide:

```python
import aspose.slides as slides

# Crie uma instância da classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Aplique um efeito gradiente ao fundo.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Salve a apresentação no disco.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir uma Imagem como Fundo de Slide**

Além de preenchimentos sólidos e gradientes, Aspose.Slides permite usar imagens como fundos de slide.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/backgroundtype/) do slide como `OWN_BACKGROUND`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) de fundo do slide como `PICTURE`.
4. Carregue a imagem que você deseja usar como fundo do slide.
5. Adicione a imagem à coleção de imagens da apresentação.
6. Use a propriedade `picture_fill_format` em [FillFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fillformat/) para atribuir a imagem como fundo.
7. Salve a apresentação modificada.

O exemplo Python a seguir mostra como definir uma imagem como fundo de um slide:

```python
import aspose.slides as slides

# Crie uma instância da classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Defina as propriedades da imagem de fundo.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Carregue a imagem.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Adicione a imagem à coleção de imagens da apresentação.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Salve a apresentação no disco.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

O exemplo de código a seguir mostra como definir o tipo de preenchimento de fundo como uma imagem em mosaico e modificar as propriedades de repetição:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Defina a imagem usada para o preenchimento de fundo.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Defina o modo de preenchimento da imagem como Ladrilho e ajuste as propriedades do ladrilho.
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
Leia mais: [**Tile Picture As Texture**](/slides/pt/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Alterar a Transparência da Imagem de Fundo**

Você pode querer ajustar a transparência da imagem de fundo de um slide para que o conteúdo do slide se destaque. O código Python a seguir mostra como alterar a transparência da imagem de fundo de um slide:

```python
transparency_value = 30  # Por exemplo.

# Obtenha a coleção de operações de transformação de imagem.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Encontre um efeito de transparência de porcentagem fixa existente.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Defina o novo valor de transparência.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **Obter o Valor de Fundo do Slide**

Aspose.Slides fornece a classe [IBackgroundEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ibackgroundeffectivedata/) para obter os valores efetivos de fundo de um slide. Essa classe expõe o [FillFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fillformat/) e o [EffectFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/effectformat/) efetivos.

Usando a propriedade `background` da classe [BaseSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslide/), você pode obter o fundo efetivo de um slide.

O exemplo Python a seguir mostra como obter o valor de fundo efetivo de um slide:

```python
import aspose.slides as slides

# Crie uma instância da classe Presentation.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Recupere o fundo efetivo, levando em conta mestre, layout e tema.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **FAQ**

**Posso redefinir um fundo personalizado e restaurar o fundo do tema/layout?**

Sim. Remova o preenchimento personalizado do slide e o fundo será herdado novamente do slide de [layout](/slides/pt/python-net/slide-layout/)/[master](/slides/pt/python-net/slide-master/) correspondente (ou seja, o [tema de fundo](/slides/pt/python-net/presentation-theme/)).

**O que acontece com o fundo se eu mudar o tema da apresentação mais tarde?**

Se um slide tiver seu próprio preenchimento, ele permanecerá inalterado. Se o fundo for herdado do [layout](/slides/pt/python-net/slide-layout/)/[master](/slides/pt/python-net/slide-master/), ele será atualizado para corresponder ao [novo tema](/slides/pt/python-net/presentation-theme/).