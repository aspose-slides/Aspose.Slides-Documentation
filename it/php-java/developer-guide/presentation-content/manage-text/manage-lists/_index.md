---
title: Gestire elenchi puntati e numerati nelle presentazioni usando PHP
linktitle: Gestire gli elenchi
type: docs
weight: 60
url: /it/php-java/manage-lists/
keywords:
- punto
- elenco puntato
- elenco numerato
- punto simbolo
- punto immagine
- punto personalizzato
- elenco a più livelli
- creare punto
- aggiungere punto
- aggiungere elenco
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come creare e formattare elenchi puntati, con immagine, a più livelli e numerati in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per PHP via Java."
---
## **Panoramica**

Aspose.Slides per PHP via Java consente di creare e formattare elenchi puntati e numerati in presentazioni PowerPoint e OpenDocument. Un elemento di elenco è un paragrafo le cui impostazioni del punto elenco sono controllate tramite il suo formato di paragrafo.

Usa il metodo [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/#getParagraphFormat--) per accedere alle impostazioni dell'elenco a livello di paragrafo. Il punto di ingresso principale è [ParagraphFormat.getBullet](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#getBullet--) che restituisce un oggetto [BulletFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/). Con questo oggetto, è possibile impostare il tipo di punto elenco, il simbolo, l'immagine, il colore, la dimensione, lo stile di numerazione e il numero iniziale.

Questo articolo mostra come:

- creare un elenco puntato con un simbolo personalizzato
- creare un punto elenco immagine
- creare un elenco a più livelli impostando la profondità del paragrafo
- creare un elenco numerato
- esaminare e modificare la formattazione dell'elenco in una presentazione esistente

## **Creare un elenco puntato**

Per creare un elenco puntato, aggiungi oggetti [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/) a un [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) e imposta [BulletFormat.setType](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/#setType-int-) su [BulletType.Symbol](https://reference.aspose.com/slides/it/php-java/aspose.slides/bullettype/#Symbol). È quindi possibile impostare [BulletFormat.setChar](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/#setChar-char-), [BulletFormat.getColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/#getColor--) e [BulletFormat.setHeight](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/#setHeight-float-) per controllare l'aspetto del punto elenco.

Il seguente codice PHP dimostra come creare un elenco puntato in una diapositiva:

```php
function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Il risultato:

![I simboli puntati](symbol_bullets.png)

## **Creare un elenco numerato**

Utilizza gli elenchi numerati quando l'ordine degli elementi è importante. Imposta [BulletFormat.setType](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/#setType-int-) su [BulletType.Numbered](https://reference.aspose.com/slides/it/php-java/aspose.slides/bullettype/#Numbered). È inoltre possibile scegliere un formato di numerazione con [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) o impostare [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) quando l'elenco deve iniziare da un valore diverso da 1.

Il seguente codice PHP mostra come creare un elenco numerato in una diapositiva:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Il risultato:

![I punti elenco numerati](numbered_bullets.png)

## **Creare un punto elenco immagine**

Aspose.Slides consente di sostituire un simbolo di punto elenco normale con un'immagine. I punti elenco immagine funzionano meglio con immagini semplici che rimangono leggibili a piccole dimensioni, come icone o piccoli file PNG trasparenti.

{{% alert color="primary" %}}
Idealmente, se si intende sostituire il simbolo di punto elenco normale con un'immagine, è consigliabile scegliere una grafica semplice con sfondo trasparente. Tale tipo di immagini funziona bene come simboli di punto elenco personalizzati.
{{% /alert %}}

Per creare un punto elenco immagine, aggiungi un'immagine a [Presentation.getImages](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getImages--) e assegna l'oggetto [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) restituito a [BulletFormat.getPicture](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/#getPicture--). Imposta [BulletFormat.setType](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/#setType-int-) su [BulletType.Picture](https://reference.aspose.com/slides/it/php-java/aspose.slides/bullettype/#Picture) prima di assegnare l'immagine.

Supponiamo di avere un "image.png":

![Un'immagine per i punti elenco](picture_for_bullets.png)

Il seguente codice PHP mostra come creare punti elenco immagine in una diapositiva:

```php
function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Il risultato:

![I punti elenco immagine](picture_bullets.png)

## **Creare un elenco a più livelli**

Usa [ParagraphFormat.setDepth](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setDepth-short-) per posizionare gli elementi dell'elenco su livelli diversi. Il livello 0 è il livello superiore, il livello 1 è annidato sotto di esso, e così via.

Il seguente codice PHP mostra come creare un elenco puntato a più livelli:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Il risultato:

![L'elenco a più livelli](multilevel_list.png)

## **Modificare un elenco esistente**

Per modificare la formattazione di un elenco in una presentazione esistente, accedi al paragrafo desiderato e aggiorna le sue impostazioni [ParagraphFormat.getBullet](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#getBullet--). Le stesse proprietà utilizzate per creare gli elenchi possono essere usate per ispezionare o modificare gli elenchi caricati da un file PPT, PPTX o ODP.

Il seguente codice PHP modifica il primo paragrafo in un text frame per utilizzare lo stile di elenco numerato:

```php
$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**È possibile esportare gli elenchi puntati e numerati in PDF o immagini?**

Sì. Aspose.Slides conserva la formattazione degli elenchi quando il formato di destinazione supporta il layout di testo corrispondente e le funzionalità dei punti elenco.

**Posso modificare gli elenchi in presentazioni esistenti?**

Sì. Carica la presentazione, accedi al paragrafo desiderato, ispeziona o aggiorna le sue impostazioni [ParagraphFormat.getBullet](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#getBullet--), e salva la presentazione.

**Gli elenchi possono contenere testo non latino?**

Sì. Il testo degli elementi dell'elenco può contenere caratteri Unicode, così puoi creare elenchi in presentazioni multilingue. Assicurati che i caratteri utilizzati nella presentazione supportino i caratteri di cui hai bisogno.