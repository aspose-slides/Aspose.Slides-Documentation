---
title: Gestisci i temi delle presentazioni PowerPoint in Python
linktitle: Tema della presentazione
type: docs
weight: 10
url: /it/python-net/presentation-theme/
keywords:
- tema PowerPoint
- tema della presentazione
- tema della diapositiva
- impostare il tema
- cambiare il tema
- gestire il tema
- colore del tema
- tavolozza aggiuntiva
- font del tema
- stile del tema
- effetto del tema
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Gestisci i temi delle presentazioni in Aspose.Slides per Python tramite .NET per creare, personalizzare e convertire file PowerPoint con un branding coerente."
---
## **Introduzione**

Un tema di presentazione definisce le proprietà dei suoi elementi di design. Quando scegli un tema, stai scegliendo un insieme coordinato di elementi visuali e le loro proprietà.

In PowerPoint, un tema include colori, [fonts](/slides/it/python-net/powerpoint-fonts/), [background styles](/slides/it/python-net/presentation-background/), ed effetti.

![elementi-del-tema](theme-constituents.png)

## **Modifica del colore del tema**

Un tema PowerPoint utilizza un insieme specifico di colori per i diversi elementi di una diapositiva. Se i valori predefiniti non ti piacciono, puoi modificarli applicando nuovi colori del tema. Per permetterti di selezionare un nuovo colore del tema, Aspose.Slides fornisce valori nell'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/python-net/aspose.slides/schemecolor/).

Questo codice Python mostra come modificare il colore di accento di un tema:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

Puoi determinare il valore effettivo del colore risultante come segue:

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# L'output di esempio:
#
# ff8064a2 (Colore [A=255, R=128, G=100, B=162])
```

Per dimostrare ulteriormente la modifica del colore, creiamo un altro elemento, gli assegniamo il colore di accento dal passaggio iniziale e poi aggiorniamo il colore del tema.

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

Il nuovo colore viene applicato automaticamente a entrambi gli elementi.

### **Imposta un colore del tema dalla tavolozza aggiuntiva**

Quando applichi trasformazioni di luminanza al colore principale del tema (1), vengono generati colori dalla tavolozza aggiuntiva (2). Puoi quindi impostare e recuperare quei colori del tema.

![colori-tavolozza-aggiuntiva](additional-palette-colors.png)

**1** — Colori principali del tema

**2** — Colori dalla tavolozza aggiuntiva

Questo codice Python dimostra come i colori della tavolozza aggiuntiva siano derivati dal colore principale del tema e poi utilizzati nelle forme:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Accento 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Accento 4, Più chiaro 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Accento 4, Più chiaro 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Accento 4, Più chiaro 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Accento 4, Più scuro 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Accento 4, Più scuro 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **Mappa `SchemeColor` ai colori `ColorScheme`**

Quando lavori con [SchemeColor](https://reference.aspose.com/slides/it/python-net/aspose.slides/schemecolor/), potresti notare che contiene i seguenti valori di colore del tema:

`BACKGROUND1`, `BACKGROUND2`, `TEXT1` e `TEXT2`.

Tuttavia, `Presentation.master_theme.color_scheme` restituisce [ColorScheme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/colorscheme/), che espone i colori corrispondenti come:

`dark1`, `dark2`, `light1` e `light2`.

Questa differenza è solo nella denominazione. Questi valori si riferiscono agli stessi slot di colore del tema e la mappatura è fissa:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Non esiste una conversione dinamica tra `TEXT`/`BACKGROUND` e `dark`/`light`. Sono semplicemente nomi alternativi per gli stessi colori del tema.

Questa differenza di denominazione proviene dalla terminologia di Microsoft Office. Le versioni più vecchie di Office usavano `Dark 1`, `Light 1`, `Dark 2` e `Light 2`, mentre le versioni UI più recenti mostrano gli stessi slot come `Text 1`, `Background 1`, `Text 2` e `Background 2`.

## **Modifica del font del tema**

Per consentirti di selezionare i font per i temi e altri scopi, Aspose.Slides utilizza questi identificatori speciali (simili a quelli di PowerPoint):

- **+mn-lt** — Font corpo Latin (Minor Latin Font)
- **+mj-lt** — Font intestazione Latin (Major Latin Font)
- **+mn-ea** — Font corpo East Asian (Minor East Asian Font)
- **+mj-ea** — Font intestazione East Asian (Major East Asian Font)

Questo codice Python mostra come assegnare il font Latin a un elemento del tema:

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

Questo esempio Python mostra come modificare il font del tema della presentazione:

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

Tutte le caselle di testo verranno aggiornate con il nuovo font.

{{% alert color="primary" title="TIP" %}}
Per ulteriori informazioni, consulta [Master PowerPoint Fonts with Python](/slides/it/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Modifica dello stile di sfondo del tema**

Per impostazione predefinita, PowerPoint fornisce 12 sfondi predefiniti, ma una presentazione tipica ne memorizza solo 3.

![todo:image_alt_text](presentation-design_8.png)

Ad esempio, dopo aver salvato una presentazione in PowerPoint, puoi eseguire il seguente codice Python per determinare quanti sfondi predefiniti contiene:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
Utilizzando la proprietà `background_fill_styles` della classe [FormatScheme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/formatscheme/), puoi aggiungere o accedere agli stili di sfondo in un tema PowerPoint.
{{% /alert %}}

Questo esempio Python mostra come impostare lo sfondo della presentazione:

```python
presentation.masters[0].background.style_index = 2  # 0 indica nessun riempimento; l'indicizzazione inizia da 1.
```

{{% alert color="primary" title="TIP" %}}
Per ulteriori informazioni, consulta [Manage Presentation Backgrounds in Python](/slides/it/python-net/presentation-background/).
{{% /alert %}}

## **Modifica degli effetti del tema**

Un tema PowerPoint tipicamente include tre valori in ciascun array di stile. Questi array si combinano in tre livelli di effetto: sottile, moderato e intenso. Ad esempio, questo è il risultato quando quegli effetti vengono applicati a una forma specifica:

![todo:image_alt_text](presentation-design_10.png)

Utilizzando le tre proprietà — `FillStyles`, `LineStyles` e `EffectStyles` — della classe [FormatScheme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/formatscheme/), puoi modificare gli elementi del tema (in modo ancora più flessibile rispetto a PowerPoint).

Questo codice Python mostra come modificare un effetto del tema alterando parti di quegli elementi:

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Le modifiche risultanti includono aggiornamenti al colore di riempimento, tipo di riempimento, effetto ombra e altre proprietà:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Posso applicare un tema a una singola diapositiva senza modificare il master?**

Sì. Aspose.Slides supporta le sovrascritture di tema a livello di diapositiva, così puoi applicare un tema locale soltanto a quella diapositiva mantenendo intatto il tema master (tramite lo [SlideThemeManager](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/slidethememanager/)).

**Qual è il metodo più sicuro per trasferire un tema da una presentazione all'altra?**

[Clona le diapositive](/slides/it/python-net/clone-slides/) insieme al loro master nella presentazione di destinazione. Questo preserva il master originale, i layout e il tema associato, così l'aspetto rimane coerente.

**Come posso vedere i valori "effettivi" dopo tutte le eredità e le sovrascritture?**

Utilizza le viste ["effective"](/slides/it/python-net/shape-effective-properties/) dell'API per tema/colore/font/effetto. Queste restituiscono le proprietà risolte e finali dopo l'applicazione del master più eventuali sovrascritture locali.