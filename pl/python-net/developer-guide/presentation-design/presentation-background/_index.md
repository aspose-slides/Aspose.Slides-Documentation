---
title: Zarządzanie tłami prezentacji w Pythonie
linktitle: Tło slajdu
type: docs
weight: 20
url: /pl/python-net/presentation-background/
keywords:
- tło prezentacji
- tło slajdu
- jednolity kolor
- gradientowy kolor
- tło obrazu
- przezroczystość tła
- właściwości tła
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak ustawiać dynamiczne tła w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona w .NET, z poradami kodowymi zwiększającymi atrakcyjność Twoich prezentacji."
---
## **Wprowadzenie**

Jednolite kolory, gradienty i obrazy są powszechnie używane jako tła slajdów. Możesz ustawić tło dla **normalnego slajdu** (pojedynczego slajdu) lub **slajdu wzorca** (obowiązuje dla wielu slajdów jednocześnie).

![Tło PowerPoint](powerpoint-background.png)

## **Ustaw jednolite tło koloru dla normalnego slajdu**

Aspose.Slides umożliwia ustawienie jednolitego koloru jako tła konkretnego slajdu w prezentacji — nawet jeśli prezentacja używa slajdu wzorca. Zmiana dotyczy tylko wybranego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/backgroundtype/) slajdu na `OWN_BACKGROUND`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/filltype/) tła slajdu na `SOLID`.
4. Użyj właściwości `solid_fill_color` w [FillFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fillformat/) aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Python pokazuje, jak ustawić niebieski jednolity kolor jako tło normalnego slajdu:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ustaw kolor tła slajdu na niebieski.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Zapisz prezentację na dysku.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw jednolite tło koloru dla slajdu wzorca**

Aspose.Slides umożliwia ustawienie jednolitego koloru jako tła slajdu wzorca w prezentacji. Slajd wzorca działa jako szablon, który kontroluje formatowanie wszystkich slajdów, więc wybierając jednolity kolor tła slajdu wzorca, zostanie on zastosowany do każdego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/backgroundtype/) slajdu wzorca (przez `masters`) na `OWN_BACKGROUND`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/filltype/) tła slajdu wzorca na `SOLID`.
4. Użyj właściwości `solid_fill_color` w [FillFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fillformat/) aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Python pokazuje, jak ustawić jednolity kolor (zielony leśny) jako tło slajdu wzorca:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Ustaw kolor tła slajdu Master na zielony leśny.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Zapisz prezentację na dysku.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw gradientowe tło dla slajdu**

Gradient to efekt graficzny tworzony przez stopniową zmianę **koloru**. Używany jako tło slajdu, gradient może sprawić, że prezentacje będą wyglądały bardziej artystycznie i profesjonalnie. Aspose.Slides umożliwia ustawienie koloru gradientowego jako tła slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/backgroundtype/) slajdu na `OWN_BACKGROUND`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/filltype/) tła slajdu na `GRADIENT`.
4. Użyj właściwości `gradient_format` w [FillFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fillformat/) aby skonfigurować preferowane ustawienia gradientu.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Python pokazuje, jak ustawić gradientowy kolor jako tło slajdu:

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Zastosuj efekt gradientowy do tła.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Zapisz prezentację na dysku.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw obraz jako tło slajdu**

Oprócz jednolitych i gradientowych wypełnień, Aspose.Slides umożliwia użycie obrazów jako tła slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/backgroundtype/) slajdu na `OWN_BACKGROUND`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/filltype/) tła slajdu na `PICTURE`.
4. Wczytaj obraz, którego chcesz użyć jako tło slajdu.
5. Dodaj obraz do kolekcji obrazów prezentacji.
6. Użyj właściwości `picture_fill_format` w [FillFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fillformat/) aby przypisać obraz jako tło.
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Python pokazuje, jak ustawić obraz jako tło slajdu:

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ustaw właściwości obrazu tła.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Wczytaj obraz.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Dodaj obraz do kolekcji obrazów prezentacji.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Zapisz prezentację na dysku.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Ustaw obraz używany do wypełnienia tła.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Ustaw tryb wypełniania obrazu na Kafelkowanie i dostosuj właściwości kafelków.
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
Czytaj więcej: [**Obraz kafelkowany jako tekstura**](/slides/pl/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Zmień przezroczystość obrazu tła**

Możesz chcieć dostosować przezroczystość obrazu tła slajdu, aby treść slajdu lepiej się wyróżniała. Poniższy kod w języku Python pokazuje, jak zmienić przezroczystość obrazu tła slajdu:

```python
transparency_value = 30  # Na przykład.

# Pobierz kolekcję operacji przekształceń obrazu.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Znajdź istniejący efekt przezroczystości o stałym procencie.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Ustaw nową wartość przezroczystości.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **Pobierz wartość tła slajdu**

Aspose.Slides udostępnia klasę [IBackgroundEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ibackgroundeffectivedata/) służącą do pobierania efektywnych wartości tła slajdu. Klasa ta udostępnia efektywne [FillFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fillformat/) i [EffectFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/effectformat/).

Korzystając z właściwości `background` klasy [BaseSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslide/), możesz uzyskać efektywne tło slajdu.

Poniższy przykład w języku Python pokazuje, jak pobrać efektywną wartość tła slajdu:

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Pobierz efektywne tło, uwzględniając master, układ i motyw.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **FAQ**

**Czy mogę zresetować niestandardowe tło i przywrócić tło motywu/układu?**

Tak. Usuń niestandardowe wypełnienie slajdu, a tło zostanie ponownie odziedziczone z odpowiedniego slajdu [układ](/slides/pl/python-net/slide-layout/)/[master](/slides/pl/python-net/slide-master/) (czyli z [tło motywu](/slides/pl/python-net/presentation-theme/)).

**Co się stanie z tłem, jeśli później zmienię motyw prezentacji?**

Jeśli slajd ma własne wypełnienie, pozostanie niezmienione. Jeśli tło jest dziedziczone z [układ](/slides/pl/python-net/slide-layout/)/[master](/slides/pl/python-net/slide-master/), zostanie zaktualizowane, aby odpowiadało [nowemu motywowi](/slides/pl/python-net/presentation-theme/).