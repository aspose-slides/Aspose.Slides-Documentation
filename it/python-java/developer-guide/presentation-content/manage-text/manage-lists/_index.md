---
title: Gestire elenchi puntati e numerati nelle presentazioni usando Python via Java
linktitle: Gestire gli elenchi
type: docs
weight: 60
url: /it/python-java/manage-lists/
keywords:
  - punto elenco
  - elenco puntato
  - elenco numerato
  - simbolo di punto elenco
  - punto immagine
  - punto personalizzato
  - elenco a più livelli
  - creare punto
  - aggiungere punto
  - aggiungere elenco
  - PowerPoint
  - OpenDocument
  - presentazione
  - Python
  - Java
  - Aspose.Slides
description: "Scopri come creare e formattare elenchi puntati, punti immagine, elenchi a più livelli e elenchi numerati in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python via Java."
---
## **Panoramica**

Aspose.Slides per Python via Java consente di creare e formattare elenchi puntati e numerati in presentazioni PowerPoint e OpenDocument. Un elemento di elenco è un paragrafo le cui impostazioni del punto elenco sono controllate tramite il suo formato di paragrafo.

Usa il metodo [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) per accedere alle impostazioni dell'elenco a livello di paragrafo. Il punto di ingresso principale è [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet), che restituisce un oggetto [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/) . Con questo oggetto, è possibile impostare il tipo di punto elenco, il simbolo, l'immagine, il colore, la dimensione, lo stile di numerazione e il numero di partenza.

Questo articolo mostra come:

- creare un elenco puntato con un simbolo personalizzato
- creare un punto elenco immagine
- creare un elenco a più livelli impostando la profondità del paragrafo
- creare un elenco numerato
- esaminare e modificare la formattazione dell'elenco in una presentazione esistente
- leggere i marcatori di elenco effettivi e i numeri insieme al testo del paragrafo

## **Creare un elenco puntato**

Per creare un elenco puntato, aggiungi oggetti [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) a un [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) e imposta [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) su [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol). Puoi quindi usare [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar), [BulletFormat.getColor](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getColor) e [BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) per controllare l'aspetto del punto elenco.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NullableBool, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    bullet_color = Color(205, 92, 92)

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar('*')
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    first_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('*')
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    second_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![I simboli di punto](symbol_bullets.png)

## **Creare un elenco numerato**

Usa gli elenchi numerati quando l'ordine degli elementi è importante. Imposta [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) su [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered). Puoi anche scegliere un formato di numerazione con [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) o usare [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) quando l'elenco deve iniziare da un valore diverso da 1.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.setText("Apple")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.setText("Orange")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.setText("Banana")
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![I punti numerati](numbered_bullets.png)

## **Creare un punto elenco immagine**

Aspose.Slides consente di sostituire un simbolo di punto elenco normale con un'immagine. I punti elenco con immagine funzionano meglio con immagini semplici che rimangono leggibili a piccole dimensioni, come icone o piccoli file PNG trasparenti.

{{% alert color="info" title="Note" %}}
Se prevedi di sostituire un simbolo di punto elenco normale con un'immagine, scegli una grafica semplice con sfondo trasparente. Tali immagini funzionano bene come simboli di punto elenco personalizzati.

Tieni presente che l'immagine verrà ridotta a una dimensione molto piccola. Per questo motivo, consigliamo vivamente di selezionare un'immagine che rimanga chiara ed efficacemente visiva quando viene usata come punto elenco in un elenco.
{{% /alert %}}

Per creare un punto elenco immagine, aggiungi un'immagine a [Presentation.getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) e assegna l'oggetto immagine restituito a [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture). Imposta [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) su [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture) prima di assegnare l'immagine.

Supponiamo di avere un'immagine chiamata "image.png":

![Un'immagine per i punti elenco](picture_for_bullets.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    image = Images.fromFile("image.png")
    try:
        bullet_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    first_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    second_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![I punti elenco immagine](picture_bullets.png)

## **Creare un elenco a più livelli**

Usa [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) per posizionare gli elementi dell'elenco a diversi livelli. Il livello 0 è il livello superiore, il livello 1 è annidato sotto di esso e così via.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().setDepth(0)
    first_paragraph.setText("My text - Depth 0")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().setDepth(1)
    second_paragraph.setText("My text - Depth 1")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().setDepth(2)
    third_paragraph.setText("My text - Depth 2")
    text_frame.getParagraphs().add(third_paragraph)

    fourth_paragraph = Paragraph()
    fourth_paragraph.getParagraphFormat().setDepth(3)
    fourth_paragraph.setText("My text - Depth 3")
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![L'elenco a più livelli](multilevel_list.png)

## **Modificare un elenco esistente**

Per modificare la formattazione dell'elenco in una presentazione esistente, accedi al paragrafo target e aggiorna le sue impostazioni [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet). Le stesse proprietà utilizzate per creare gli elenchi possono essere usate per esaminare o modificare gli elenchi caricati da un file PPT, PPTX o ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NumberedBulletStyle, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(1)
    paragraph.getParagraphFormat().setMarginLeft(30)
    paragraph.getParagraphFormat().setIndent(-20)

    presentation.save("updated_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Leggere i valori effettivi dei punti elenco**

Durante l'estrazione del contenuto di una presentazione, conserva i marcatori di elenco accanto al testo del paragrafo. Chiama [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective) e accedi a `getBullet` per ottenere il formato effettivo del punto elenco. Controlla il suo `getType` prima di leggere `getActualBulletValue`.

Per gli elenchi numerati, distingui questi tre valori:

- `getNumberedBulletStyle` determina il formato, ad esempio numeri arabi seguiti da un punto o lettere minuscole seguite da un punto.
- `getNumberedBulletStartWith` specifica il numero iniziale per un gruppo di paragrafi numerati.
- `getActualBulletValue` restituisce il marcatore formattato per un determinato paragrafo. Ad esempio, il secondo elemento in un elenco che inizia da 5 restituisce `6.`.

Conserva [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDepth) con ogni paragrafo per mantenere il suo livello di annidamento. Il marcatore effettivo non codifica l'intera gerarchia: un elemento annidato può restituire `c.` invece di un'etichetta combinata come `6.c.`.

Il seguente esempio autonomo crea elenchi, li salva in una presentazione e ricarica la presentazione per segnalare il testo di ogni paragrafo, la profondità, il tipo di punto elenco e il valore effettivo. Il piccolo marcatore immagine blu è creato da SVG in linea.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, SvgImage
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Creare un marcatore immagine senza un file immagine esterno.
    svg = SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.getImages().addImage(svg)

    def add_paragraph(text, depth, bullet_type, start, style):
        paragraph = Paragraph()
        paragraph.setText(text)

        paragraph_format = paragraph.getParagraphFormat()
        paragraph_format.setDepth(depth)
        paragraph_format.setMarginLeft(30 + depth * 40)
        paragraph_format.setIndent(-28)
        paragraph_format.setSpaceAfter(8)
        paragraph_format.getDefaultPortionFormat().setFontHeight(22)
        paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        paragraph_format.getBullet().setType(bullet_type)
        paragraph_format.getBullet().setBulletHardColor(NullableBool.True_)
        paragraph_format.getBullet().getColor().setColor(Color.BLACK)
        if bullet_type == BulletType.Numbered:
            paragraph_format.getBullet().setNumberedBulletStyle(style)
            paragraph_format.getBullet().setNumberedBulletStartWith(start)
        elif bullet_type == BulletType.Symbol:
            paragraph_format.getBullet().setChar('\u2022')
        elif bullet_type == BulletType.Picture:
            paragraph_format.getBullet().getPicture().setImage(bullet_image)

        text_frame.getParagraphs().add(paragraph)

    add_paragraph("First item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Second item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod)
    add_paragraph("Back to top level", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Symbol marker", 0, BulletType.Symbol, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("No bullet", 0, BulletType.None_, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Picture marker", 0, BulletType.Picture, 1, NumberedBulletStyle.BulletArabicPeriod)
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

loaded_presentation = Presentation("actual_bullet_values.pptx")
try:
    loaded_shape = loaded_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    type_names = {
        BulletType.Numbered: "Numbered",
        BulletType.Symbol: "Symbol",
        BulletType.None_: "None",
        BulletType.Picture: "Picture",
    }
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.getTextFrame().getParagraphs():
        bullet = paragraph.getParagraphFormat().getEffective().getBullet()
        bullet_type = bullet.getType()
        if bullet_type in (BulletType.Numbered, BulletType.Symbol):
            marker = bullet.getActualBulletValue()
        elif bullet_type == BulletType.None_:
            marker = f"{bullet.getActualBulletValue()} (no bullet)"
        elif bullet_type == BulletType.Picture:
            marker = f"{bullet.getActualBulletValue()} (image required)"
        else:
            marker = "unsupported bullet type"
        type_name = type_names.get(bullet_type, "Unknown")
        print(f"{paragraph.getText()} | {paragraph.getParagraphFormat().getDepth()} | {type_name} | {marker}")
finally:
    loaded_presentation.dispose()
```

Gli elenchi di origine sono mostrati di seguito.

![Elenchi che iniziano da 5, elementi con lettere annidate e numeri romani, un marcatore simbolo, un paragrafo senza punto elenco e un marcatore immagine blu](actual_bullet_values.png)

Il report corrisponde ai marcatori visualizzati in PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | None (no bullet)
Picture marker | 0 | Picture | None (image required)
```

Per [BulletType.None_ e BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/) `getActualBulletValue` restituisce `None` (Java `null`), non una stringa vuota. Gestisci questi tipi separatamente: il primo non ha marcatore, mentre il secondo richiede l'estrazione dell'immagine del punto elenco separatamente. Un punto elenco immagine non può essere riprodotto solo estraendo un marcatore di testo.

## **FAQ**

**È possibile esportare elenchi puntati e numerati in PDF o immagini?**

Sì. Aspose.Slides conserva la formattazione dell'elenco quando il formato di destinazione supporta il layout del testo corrispondente e le funzionalità dei punti elenco.

**Posso modificare gli elenchi in presentazioni esistenti?**

Sì. Carica la presentazione, accedi al paragrafo target, ispeziona o aggiorna le sue impostazioni [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet), e salva la presentazione.

**Gli elenchi possono contenere testo non latino?**

Sì. Il testo degli elementi dell'elenco può contenere caratteri Unicode, quindi è possibile creare elenchi in presentazioni multilingue. Assicurati che i caratteri utilizzati nella presentazione supportino i caratteri di cui hai bisogno.