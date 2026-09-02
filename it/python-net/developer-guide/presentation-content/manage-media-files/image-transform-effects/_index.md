---
title: Gestire gli effetti di trasformazione immagine nelle presentazioni con Python
linktitle: Effetti di trasformazione immagine
type: docs
weight: 11
url: /it/python-net/image-transform-effects/
keywords:
- trasformazione immagine
- effetto immagine
- luminosità
- contrasto
- scala di grigi
- duotono
- tinta
- HSL
- sostituzione colore
- sfocatura
- trasparenza
- effetto alpha
- catena di effetti
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Applica, concatena, ispeziona, rimuovi e verifica gli effetti di trasformazione immagine per i riquadri immagine con Aspose.Slides per Python tramite .NET."
---
## **Panoramica**

Aspose.Slides rappresenta le regolazioni dell'immagine come una raccolta ordinata di operazioni di trasformazione dell'immagine. Per un riquadro immagine, inizia con il [Picture](https://reference.aspose.com/slides/it/python-net/aspose.slides/picture/) del riquadro e accedi alla sua proprietà [image_transform](https://reference.aspose.com/slides/it/python-net/aspose.slides/picture/image_transform/). La [ImageTransformOperationCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/) restituita ti consente di aggiungere, enumerare, ispezionare, rimuovere e cancellare gli effetti senza riscrivere i byte originali dell'immagine.

Questo articolo dimostra un flusso di lavoro completo per luminosità e contrasto, trasformazioni di colore, sfocatura, trasparenza, catene di effetti ordinate, valori effettivi, rimozione e verifica del round‑trip PPTX.

## **Comprendere la proprietà degli effetti e il riutilizzo dell'immagine**

Una risorsa immagine e l'immagine che la visualizza sono oggetti diversi:

- [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) memorizza o fa riferimento ai dati dell'immagine sorgente di proprietà della presentazione.
- [Picture](https://reference.aspose.com/slides/it/python-net/aspose.slides/picture/) appartiene a un riempimento immagine e fa riferimento a una risorsa immagine conservando la raccolta di trasformazioni dell'immagine.
- [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) è la forma della diapositiva che possiede il relativo riempimento immagine, la geometria, le impostazioni di ritaglio e altri formati a livello di riquadro.

Pertanto, le operazioni di trasformazione dell'immagine non modificano i byte in [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/). Quando lo stesso `PPImage` viene passato a [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_picture_frame/) più di una volta, ogni nuovo riquadro immagine riceve il proprio `Picture` e la propria raccolta di trasformazioni. Applicare la scala di grigi a un riquadro non rende gli altri riquadri in scala di grigi, anche se tutti riutilizzano la stessa risorsa immagine incorporata.

Lo stesso modello `Picture.image_transform` è utilizzato anche da altri riempimenti immagine, come una forma o lo sfondo della diapositiva. Gli esempi seguenti si concentrano sui riquadri immagine.

## **Utilizzare intervalli e unità di parametro validi**

I metodi dimostrati utilizzano i seguenti intervalli semantici e unità. Mantieni i valori entro questi intervalli anche se una versione specifica della libreria non rifiuta immediatamente ogni valore fuori intervallo; il formato di destinazione della presentazione può normalizzare, omettere o rifiutare dati non validi durante il salvataggio o quando PowerPoint apre il file.

| Operazione | Parametri | Intervallo valido e unità |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` fino a `100`, percentuale; `0` lascia il componente invariato. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | Nessun parametro | Nessun parametro numerico. Alpha rimane invariato. |
| [add_duotone_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Due colori per pixel scuri e chiari. I canali RGB e alpha usano `0` fino a `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | La tonalità è da `0` inclusivo a `360` esclusivo, in gradi; la quantità è da `-100` a `100`, percentuale. |
| [add_hsl_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | La tonalità è da `0` inclusivo a `360` esclusivo, in gradi; saturazione e luminanza sono da `-100` a `100`, percentuale. |
| [add_color_replace_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | Il colore di sostituzione usa valori di canale da `0` a `255`. I valori alpha esistenti rimangono invariati. |
| [add_blur_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Il raggio è non negativo e misurato in punti; `grow` è un Boolean che controlla se il contenuto sfocato può estendersi oltre i limiti originali. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Percentuale non negativa. Usa `0` a `100` per una normale scala di opacità: `0` è completamente trasparente e `100` mantiene l'alpha esistente. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` a `100`, percentuale di opacità. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` a `100`, soglia alpha percentuale. I valori inferiori diventano trasparenti; i valori uguali o superiori diventano opachi. |

Per la modulazione alpha fissa, trasparenza e opacità sono complementari. Ad esempio, il 35% di trasparenza corrisponde a un valore di modulazione alpha del 65%.

## **Applicare luminosità e contrasto**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) restituisce un'operazione [BrightnessContrast](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/brightnesscontrast/). Le impostazioni scalari sono fornite al momento della creazione dell'operazione. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) restituisce valori calcolati di sola lettura che possono essere ispezionati o registrati.

L'esempio seguente aumenta la luminosità del 15% e il contrasto del 20%, poi rende un'anteprima senza modificare l'immagine incorporata:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/brightnesscontrast/) è un'estensione degli effetti immagine di Office 2010 e risulta meno portabile rispetto all'effetto luminanza standard DrawingML. Quando luminosità e contrasto devono rimanere modificabili dopo un round‑trip PPTX, usa [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) e verifica il risultato dopo aver riaperto il file. La sezione limitazioni di formato spiega questa distinzione in modo più dettagliato.

## **Applicare trasformazioni di colore**

Gli effetti colore possono essere applicati indipendentemente a diversi riquadri immagine che riutilizzano una singola risorsa immagine. L'esempio seguente crea cinque riquadri e applica scala di grigi, duotono, tinta, regolazione HSL e sostituzione colore.

[Duotone](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/duotone/) contiene due parametri colore modificabili indipendentemente: `color1` mappa i pixel scuri, mentre `color2` mappa i pixel chiari. Questo lo rende un esempio utile di effetto le cui impostazioni sono più complesse di un singolo valore scalare.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) sostituisce il colore di ogni pixel con un colore fisso preservando l'alpha. È diverso da [add_color_change_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), che mappa un colore sorgente in un altro e espone entrambi i formati di colore sorgente e destinazione.

## **Aggiungere sfocatura, trasparenza e effetti Alpha**

[add_blur_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) influisce su tutti i canali colore, incluso l'alpha. Imposta `grow` a `True` quando il bordo sfocato può estendersi oltre i limiti originali dell'immagine.

Per una trasparenza uniforme, usa [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Moltiplica ogni valore alpha esistente, così i pixel parzialmente trasparenti rimangono proporzionalmente differenti. [add_alpha_replace_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) invece assegna un unico valore alpha a tutti i pixel. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) converte l'alpha in due livelli basati su una soglia.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

Altre operazioni alpha senza parametri includono [add_alpha_ceiling_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), che rende ogni alpha non zero completamente opaco; [add_alpha_floor_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), che rende ogni alpha inferiore al 100% completamente trasparente; e [add_alpha_inverse_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), che cambia l'alpha in `100% - alpha`.

## **Costruire una catena di effetti ordinata**

Ogni metodo `add_..._effect` aggiunge una nuova operazione alla fine della raccolta. Il renderer utilizza la raccolta come pipeline ordinata: l'output dell'operazione 0 diventa l'input dell'operazione 1, e così via. Di conseguenza, le stesse operazioni in un ordine diverso possono produrre un'immagine diversa.

Ad esempio, scala di grigi seguita da tinta rimuove prima le informazioni cromatiche e poi ricolora il risultato di luminanza. Tinta seguita da scala di grigi rimuove nuovamente la tinta. Analogamente, la sostituzione alpha può sovrascrivere i valori alpha calcolati da operazioni precedenti, mentre la modulazione alpha preserva le loro differenze relative.

L'esempio seguente costruisce una catena di quattro operazioni, la salva come PPTX, riapre la presentazione, verifica sia i tipi di operazione sia il loro ordine, e rende il risultato riaperto:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

La raccolta non impone una matrice di compatibilità che limiti colori, alpha e operazioni di sfocatura a catene separate. Possono essere combinati, ma le combinazioni non sono sempre utili. Una sostituzione colore fissa rimuove le variazioni RGB prodotte da effetti colore precedenti; la scala di grigi dopo duotono elimina i due colori selezionati; e le operazioni alpha ceiling, floor, replace o bi‑level possono scartare i dettagli alpha creati in precedenza. Costruisci la catena secondo la sequenza di elaborazione pixel desiderata anziché trattare i singoli elementi come flag di formattazione non ordinati.

## **Ispezionare valori modificabili ed effettivi**

Un'operazione modificabile è l'oggetto memorizzato in `Picture.image_transform`. A seconda dell'effetto, può esporre membri scrivibili direttamente. Ad esempio, [Blur](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/blur/) espone le proprietà scrivibili `radius` e `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/alphamodulatefixed/) espone la proprietà scrivibile `amount`, e [AlphaBiLevel](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/alphabilevel/) espone la proprietà scrivibile `threshold`. Gli effetti colore come [Duotone](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/duotone/) espongono oggetti [ColorFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/colorformat/) mutabili.

Alcune operazioni, incluse [BrightnessContrast](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/tint/), e [AlphaReplace](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/alphareplace/), non espongono i loro scalari di creazione come proprietà scrivibili. Per modificare quelle impostazioni, rimuovi l'operazione e aggiungi una sostituzione nella posizione necessaria.

I dati effettivi restituiti da `get_effective()` sono calcolati e di sola lettura. Sono utili per risolvere colori dipendenti dal tema e leggere i valori normalizzati che il renderer utilizza, ma non costituiscono un'ulteriore superficie di modifica. L'esempio seguente enumera la catena e ispeziona i valori effettivi dove l'API corrispondente li fornisce:

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

Gli effetti senza parametri come scala di grigi, alpha ceiling e alpha inverse hanno comunque un oggetto di dati effettivi, ma non ci sono impostazioni scalari da stampare. La loro presenza e posizione nella raccolta sono le informazioni importanti.

## **Rimuovere o cancellare le trasformazioni immagine**

Usa [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) per rimuovere un'operazione per indice. Poiché gli indici si spostano dopo la rimozione, cerca prima il bersaglio e rimuovilo dopo l'enumerazione. Usa `clear()` per rimuovere l'intera catena.

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

Rimuovere o cancellare le trasformazioni modifica solo la formattazione dell'immagine. Non elimina, ricomprime o altera in altro modo la risorsa [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) riutilizzata.

## **Considerare i formati di presentazione e i target di esportazione**

Le trasformazioni immagine hanno origine in DrawingML, quindi PPTX è il formato modificabile preferito per le catene di effetti. Anche con PPTX, non ogni operazione ha la stessa portabilità:

- Le operazioni DrawingML standard come luminanza, scala di grigi, duotono, tinta, HSL, sfocatura e operazioni alpha comuni hanno la migliore possibilità di sopravvivere a un round‑trip PPTX. Riapri sempre il file generato e controlla la raccolta quando la conservazione è un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/brightnesscontrast/) è un'estensione di Office 2010 piuttosto che l'operazione luminanza standard DrawingML. Può essere usata per il rendering in memoria, ma non è garantito che rimanga come operazione `BrightnessContrast` modificabile dopo il salvataggio e la riapertura di PPTX. Preferisci [add_luminance_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) per regolazioni di luminosità e contrasto persistenti.
- Il formato binario PPT precede il modello completo di effetti DrawingML. Il salvataggio in PPT può omettere operazioni non supportate, ridurre una catena a un sottoinsieme supportato o approssimare l'aspetto. Non usare PPT come formato di verifica per una catena modificabile complessa.
- Il rendering in PNG, JPEG, TIFF, PDF, SVG, HTML o altri output visivi applica la catena supportata all'aspetto renderizzato. Quei output non contengono una `ImageTransformOperationCollection` modificabile; i formati raster appiattiscono il risultato in pixel, e le esportazioni documento o vettoriali memorizzano la propria rappresentazione di rendering.
- Gli effetti non rendono un'immagine collegata autonoma. Il rendering di un'immagine collegata dipende comunque dalla risorsa collegata disponibile quando la presentazione viene caricata.

Diversi consumatori di presentazioni possono renderizzare casi limite in modo diverso, specialmente quando sono combinate più operazioni alpha o di quantizzazione colore. Per output critici, testa sia il round‑trip modificabile sia il formato di esportazione finale con la stessa versione di Aspose.Slides utilizzata in produzione.

## **FAQ**

**Gli effetti di trasformazione immagine modificano i dati dell'immagine incorporata?**

No. Le operazioni appartengono al `Picture` usato dal riempimento immagine. I byte sottostanti di `PPImage` rimangono invariati.

**Due riquadri immagine che riutilizzano la stessa immagine condivideranno i loro effetti?**

No. Riutilizzare un `PPImage` evita dati immagine duplicati, ma ogni riquadro immagine ha normalmente un `Picture` separato e una propria raccolta di trasformazioni immagine.

**È possibile combinare effetti colore, sfocatura e alpha?**

Sì. La raccolta li accetta in una catena ordinata. Considera cosa fa ogni operazione sull'output della precedente, poiché le operazioni di sostituzione e soglia possono scartare dettagli di colore o alpha precedenti.

**Perché i valori effettivi sono di sola lettura?**

I dati effettivi rappresentano i valori calcolati utilizzati per il rendering, inclusi i colori risolti. Modifica l'operazione memorizzata nella raccolta di trasformazioni dove esistono membri scrivibili; altrimenti rimuovila e aggiungi una sostituzione con nuovi parametri di creazione.

**Quale formato devo usare per preservare una catena di trasformazioni?**

Usa PPTX e verifica il file riaprendolo. Il vecchio PPT non può rappresentare il modello completo degli effetti DrawingML, e i formati di esportazione renderizzati preservano l'aspetto anziché le operazioni di trasformazione modificabili.