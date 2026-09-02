---
title: Gestire i paragrafi di testo PowerPoint in PHP
linktitle: Gestire Paragrafo
type: docs
weight: 40
url: /it/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
  - aggiungere testo
  - aggiungere paragrafo
  - gestire testo
  - gestire paragrafo
  - gestire punto elenco
  - rientro paragrafo
  - rientro sospeso
  - punto elenco paragrafo
  - elenco numerato
  - elenco puntato
  - proprietà del paragrafo
  - importare HTML
  - testo in HTML
  - paragrafo in HTML
  - paragrafo in immagine
  - testo in immagine
  - esportare paragrafo
  - PowerPoint
  - presentazione
  - PHP
  - Aspose.Slides
description: "Scopri come creare e formattare paragrafi, porzioni, punti elenco, elenchi numerati, rientri, contenuti HTML e immagini dei paragrafi con Aspose.Slides per PHP via Java."
---
## **Panoramica**

Aspose.Slides per PHP via Java rappresenta il testo come una gerarchia di TextFrame, Paragraph e Portion:

* [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) rappresenta il contenitore di testo in una forma e fornisce l'accesso alla sua collezione di paragrafi.
* [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/) rappresenta un paragrafo in un TextFrame e fornisce l'accesso alle sue porzioni e alla formattazione a livello di paragrafo.
* [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/) rappresenta un blocco di testo all'interno di un paragrafo. Ogni porzione può avere il proprio testo e formattazione a livello di carattere.

Un paragrafo può quindi contenere testo con diversi caratteri, colori, dimensioni e altra formattazione utilizzando più porzioni.

## **Creare e Formattare i Paragrafi**

### **Creare Paragrafi con Più Porzioni**

I seguenti passaggi creano un TextFrame con tre paragrafi, ognuno contenente tre porzioni:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Accedi alla diapositiva rilevante tramite il suo indice.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) della forma.
5. Usa il paragrafo predefinito e aggiungi altri due oggetti [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/) al TextFrame.
6. Aggiungi sufficienti oggetti [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/) per ogni paragrafo in modo che contenga tre porzioni. Il paragrafo predefinito contiene già una porzione vuota.
7. Imposta il testo di ogni porzione.
8. Applica la formattazione a livello di carattere tramite [Portion::getPortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/#getPortionFormat--).
9. Salva la presentazione modificata.

Questo esempio PHP implementa i passaggi:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Creare Elenchi Puntati e Numerati**

### **Creare un Elenco Puntato o Numerato**

I punti elenco e la numerazione rendono gli elementi correlati più facili da scansionare. In Aspose.Slides, le impostazioni dell'elenco sono definite tramite [BulletFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/).

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Accedi alla diapositiva rilevante tramite il suo indice.
3. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva selezionata.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) della forma.
5. Rimuovi il paragrafo predefinito dal TextFrame.
6. Crea un [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/) per un punto simbolo.
7. Imposta [BulletFormat::setType](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/#setType-int-) a [BulletType::Symbol](https://reference.aspose.com/slides/it/php-java/aspose.slides/bullettype/) e specifica il carattere del punto.
8. Imposta il testo del paragrafo, l'indentazione, il colore del punto e l'altezza del punto.
9. Aggiungi il paragrafo al TextFrame.
10. Crea un secondo paragrafo e imposta [BulletFormat::setType](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/#setType-int-) a [BulletType::Numbered](https://reference.aspose.com/slides/it/php-java/aspose.slides/bullettype/).
11. Configura lo stile del punto numerato e aggiungi il paragrafo al TextFrame.
12. Salva la presentazione.

Questo esempio PHP crea un punto simbolo e un punto numerato:

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Utilizzare Punti Immagine**

I punti immagine consentono di utilizzare un'immagine personalizzata al posto di un simbolo o di un numero.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Accedi alla diapositiva rilevante tramite il suo indice.
3. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) e accedi al suo [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/).
4. Rimuovi il paragrafo predefinito dal TextFrame.
5. Carica l'immagine del punto e aggiungila alla raccolta di immagini della presentazione come [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/).
6. Crea un [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/) e imposta il suo testo.
7. Imposta [BulletFormat::setType](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/#setType-int-) a [BulletType::Picture](https://reference.aspose.com/slides/it/php-java/aspose.slides/bullettype/).
8. Assegna l'immagine tramite [BulletFormat::getPicture](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/#getPicture--) e imposta l'altezza del punto.
9. Aggiungi il paragrafo al TextFrame.
10. Salva la presentazione modificata.

Questo esempio PHP crea un punto immagine:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **Creare un Elenco Multilivello**

Imposta [ParagraphFormat::setDepth](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setDepth-short-) per collocare i paragrafi a diversi livelli di un elenco. Il livello più alto ha una profondità di `0`.

1. Crea una [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e accedi a una diapositiva.
2. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) e rimuovi il paragrafo predefinito dal suo TextFrame.
3. Crea quattro paragrafi e configura i loro simboli di punto.
4. Imposta i loro valori [ParagraphFormat::setDepth](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setDepth-short-) a `0`, `1`, `2` e `3`.
5. Aggiungi i paragrafi al TextFrame e salva la presentazione.

Questo esempio PHP crea un elenco puntato a quattro livelli:

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Iniziare gli Elementi Numerati dell'Elenco con Valori Personalizzati**

Usa [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) per impostare il numero iniziale visualizzato per un paragrafo numerato.

1. Crea una [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e aggiungi un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) a una diapositiva.
2. Rimuovi il paragrafo predefinito dal TextFrame della forma.
3. Crea tre paragrafi numerati.
4. Imposta [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) a `2`, `3` e `7` per i rispettivi paragrafi.
5. Aggiungi i paragrafi al TextFrame e salva la presentazione.

Questo esempio PHP assegna un numero iniziale personalizzato a ciascun paragrafo:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Controllare il Layout del Paragrafo e le Proprietà di Fine**

### **Impostare un Rientro della Prima Linea**

Usa [ParagraphFormat::setIndent](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setIndent-float-) per controllare il rientro della prima linea di un paragrafo. Questo metodo sposta solo la prima linea rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima linea a destra, mentre le linee rimanenti rimangono allineate al corpo del paragrafo.

Usa [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) quando è necessario spostare l'intero paragrafo. Usa [ParagraphFormat::setIndent](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setIndent-float-) quando devi spostare solo la prima linea.

L'esempio seguente crea diversi paragrafi e applica diversi valori di [ParagraphFormat::setIndent] per dimostrare come il rientro della prima linea influisce sul layout del paragrafo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Accedi alla diapositiva target.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) della forma e rimuovi il paragrafo predefinito.
5. Crea diversi paragrafi e imposta valori diversi di [ParagraphFormat::setIndent] per ciascuno.
6. Aggiungi i paragrafi al TextFrame.
7. Salva la presentazione modificata.

Questo codice PHP mostra come impostare un rientro di paragrafo:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Il rientro della prima linea dei paragrafi](first_line_indent.png)

### **Impostare un Rientro Sospeso**

Un rientro sospeso è un layout di paragrafo in cui la prima linea inizia a sinistra delle linee rimanenti. In Aspose.Slides, crei questo effetto con [ParagraphFormat::setIndent](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setIndent-float-). Passa un valore negativo per spostare la prima linea a sinistra rispetto al corpo del paragrafo.

In pratica, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) definisce la posizione sinistra del corpo del paragrafo, e [ParagraphFormat::setIndent](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setIndent-float-) definisce la posizione della prima linea rispetto a quel margine. Per creare un rientro sospeso, passa un valore positivo a `setMarginLeft` e un valore negativo a `setIndent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le linee a capo devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima linea.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Accedi alla diapositiva target.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) della forma e rimuovi il paragrafo predefinito.
5. Crea paragrafi e passa un valore positivo a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) per ciascun paragrafo.
6. Passa un valore negativo a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setIndent-float-) per creare l'effetto di rientro sospeso.
7. Aggiungi i paragrafi al TextFrame.
8. Salva la presentazione modificata.

Questo codice PHP mostra come impostare un rientro sospeso per un paragrafo:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Il rientro sospeso dei paragrafi](hanging_indent.png)

### **Impostare le Proprietà di Fine Esecuzione del Paragrafo**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) controlla la formattazione del segno di fine paragrafo. Il seguente esempio PHP assegna una dimensione del carattere e un font latino al segno di fine del secondo paragrafo:

1. Carica una [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e accedi a una diapositiva.
2. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) e rimuovi il suo paragrafo predefinito.
3. Crea due paragrafi e aggiungi porzioni di testo a ciascuno.
4. Crea un [PortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/portionformat/) per il segno di fine del secondo paragrafo.
5. Imposta [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) e [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Assegna il formato con [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) e salva la presentazione.

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Importare ed Esportare il Contenuto del Paragrafo**

### **Importare Testo HTML nei Paragrafi**

Usa [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) per convertire il markup HTML in paragrafi e porzioni in un TextFrame.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Accedi a una diapositiva e aggiungi un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/).
3. Accedi al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) della forma e rimuovi il paragrafo predefinito.
4. Leggi il file HTML sorgente.
5. Passa la stringa HTML a [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Salva la presentazione modificata.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **Esportare il Testo del Paragrafo in HTML**

Usa [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) per esportare un intervallo selezionato di paragrafi in HTML.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e carica la presentazione desiderata.
2. Accedi alla diapositiva e trova il [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) che contiene il testo.
3. Accedi al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) della forma.
4. Chiama [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) con l'indice del paragrafo iniziale e il numero di paragrafi da esportare.
5. Scrivi la stringa HTML restituita in un file.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **Renderizzare un Paragrafo come Immagine**

[Paragraph::getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/#getImage--) renderizza direttamente un singolo paragrafo e restituisce un [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/). Salva il risultato in un file o stream con [IImage::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/#save-java.lang.String-int-). Non è necessario renderizzare la forma contenente o ritagliare manualmente un bitmap.

[Paragraph::getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/#getImage--) può restituire `null` se il paragrafo non può essere trovato nella sua collezione padre, non ha limiti di rendering validi, o non può essere renderizzato. Controlla il risultato prima di salvarlo e rilascia l'immagine restituita dopo l'uso.

#### **Renderizzare un Paragrafo alla Scala Predefinita**

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, in cui la prima forma è una casella di testo contenente tre paragrafi.

![La casella di testo con tre paragrafi](paragraph_to_image_input.png)

Il seguente esempio PHP renderizza il secondo paragrafo in una forma di testo normale alla scala predefinita e salva l'immagine restituita in formato PNG. Il blocco `finally` garantisce che l'immagine venga rilasciata correttamente.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

![L'immagine del paragrafo](paragraph_to_image_output.png)

#### **Renderizzare un Paragrafo in una Cella di Tabella con Scaling**

Usa la sovraccarica di [Paragraph::getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/#getImage-float-float-) che accetta i parametri `$scaleX` e `$scaleY` per impostare i fattori di scala orizzontale e verticale. Il seguente esempio PHP crea una tabella, renderizza il paragrafo nella sua prima cella al doppio della larghezza e altezza predefinite, e salva il risultato come immagine PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

Un fattore di scala di `1` mantiene quell'asse alla sua dimensione pixel predefinita. Per esempio, `2` per entrambi i fattori produce un'immagine la cui larghezza e altezza sono circa il doppio delle dimensioni predefinite, risultando in quattro volte più pixel. Fattori più grandi producono generalmente testo più nitido per lo zoom o output ad alta risoluzione, ma aumentano anche l'uso di memoria e le dimensioni del file. Fattori inferiori a `1` producono immagini più piccole con meno dettagli. Usa fattori uguali per preservare il rapporto d'aspetto del paragrafo; fattori orizzontali e verticali diversi stirano l'output indipendentemente.

Renderizzare un'intera forma con [Shape::getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getImage--) resta utile quando l'output deve includere il riempimento, il bordo o altro contesto visivo della forma. Per un'immagine solo del paragrafo, usa [Paragraph::getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/#getImage--).

## **FAQ**

**Posso disabilitare completamente l'andare a capo all'interno di un TextFrame?**

Sì. Imposta [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/#setWrapText-byte-) per disabilitare l'andare a capo così le linee non si interrompono ai bordi del TextFrame.

**Come posso ottenere i limiti esatti sullo slide di un paragrafo specifico?**

Usa [Paragraph::getRect](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/#getRect--) per recuperare il rettangolo di delimitazione del paragrafo. [Portion::getRect](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/#getRect--) fornisce i limiti di una singola porzione.

**Dove viene controllato l'allineamento del paragrafo (sinistra, destra, centro o giustificato)?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setAlignment-int-) è un'impostazione a livello di paragrafo e si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare la lingua di correzione per parte di un paragrafo?**

Sì. Imposta [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) per le singole porzioni, così un paragrafo può contenere testo in più lingue.