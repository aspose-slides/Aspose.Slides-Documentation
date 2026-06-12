---
title: Gestire i paragrafi di testo PowerPoint in PHP
linktitle: Gestisci Paragrafo
type: docs
weight: 40
url: /it/php-java/manage-paragraph/
keywords:
- aggiungi testo
- aggiungi paragrafo
- gestisci testo
- gestisci paragrafo
- gestisci punto elenco
- indentazione paragrafo
- indentazione a penzolante
- punto elenco paragrafo
- elenco numerato
- elenco puntato
- proprietà paragrafo
- importa HTML
- testo in HTML
- paragrafo in HTML
- paragrafo in immagine
- testo in immagine
- esporta paragrafo
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Domina la formattazione dei paragrafi con Aspose.Slides per PHP tramite Java — ottimizza allineamento, spaziatura e stile in presentazioni PPT, PPTX e ODP."
---
## **Introduzione**

Aspose.Slides fornisce tutte le classi necessarie per lavorare con i testi, i paragrafi e le porzioni di PowerPoint.

* Aspose.Slides fornisce la classe [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) per consentire di aggiungere oggetti che rappresentano un paragrafo. Un oggetto `TextFame` può contenere uno o più paragrafi (ogni paragrafo è creato tramite un ritorno a capo).
* Aspose.Slides fornisce la classe [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/) per consentire di aggiungere oggetti che rappresentano porzioni. Un oggetto `Paragraph` può contenere una o più porzioni (collezione di oggetti porzione).
* Aspose.Slides fornisce la classe [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/) per consentire di aggiungere oggetti che rappresentano testi e le loro proprietà di formattazione.

Un oggetto `Paragraph` è in grado di gestire testi con diverse proprietà di formattazione tramite i suoi oggetti `Portion` sottostanti.

## **Aggiungere più paragrafi contenenti più porzioni**

Questi passaggi mostrano come aggiungere un riquadro di testo contenente 3 paragrafi e ogni paragrafo contenente 3 porzioni:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Accedere al riferimento della diapositiva desiderata tramite il suo indice.
3. Aggiungere un rettangolo [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
4. Ottenere l'`ITextFrame` associato all'[AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/).
5. Creare due oggetti [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/) e aggiungerli alla collezione di paragrafi del [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/).
6. Creare tre oggetti [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/) per ciascun nuovo `Paragraph` (due oggetti Portion per il paragrafo predefinito) e aggiungere ogni oggetto `Portion` alla collezione di porzioni di ciascun `Paragraph`.
7. Impostare del testo per ogni porzione.
8. Applicare le caratteristiche di formattazione preferite a ciascuna porzione utilizzando le proprietà di formattazione esposte dall'oggetto `Portion`.
9. Salvare la presentazione modificata.

Questo codice PHP è un'implementazione dei passaggi per aggiungere paragrafi contenenti porzioni:

```php
# Istanzia una classe Presentation che rappresenta un file PPTX
$pres = new Presentation();
try {
    # Accesso alla prima diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Aggiungi un AutoShape di tipo Rettangolo
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Accedi al TextFrame dell'AutoShape
    $tf = $ashp->getTextFrame();
    # Crea Paragraph e Portion con formati di testo diversi
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # Scrivi il PPTX su disco
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Gestire i punti elenco del paragrafo**

Le liste puntate aiutano a organizzare e presentare le informazioni in modo rapido ed efficiente. I paragrafi puntati sono sempre più facili da leggere e comprendere.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Accedere al riferimento della diapositiva desiderata tramite il suo indice.
3. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva selezionata.
4. Accedere al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) dell'autoshape.
5. Rimuovere il paragrafo predefinito nel `TextFrame`.
6. Creare la prima istanza di paragrafo usando la classe [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/).
7. Impostare il `Type` del punto elenco per il paragrafo su `Symbol` e impostare il carattere del punto.
8. Impostare il `Text` del paragrafo.
9. Impostare l'`Indent` del paragrafo per il punto elenco.
10. Impostare un colore per il punto elenco.
11. Impostare un'altezza per il punto elenco.
12. Aggiungere il nuovo paragrafo alla collezione di paragrafi del `TextFrame`.
13. Aggiungere il secondo paragrafo e ripetere il processo descritto nei passaggi da 7 a 13.
14. Salvare la presentazione.

Questo codice PHP mostra come aggiungere un punto elenco a un paragrafo:

```php
# Istanzia una classe Presentation che rappresenta un file PPTX
$pres = new Presentation();
try {
    # Accede alla prima diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Aggiunge e accede a Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accede al TextFrame dell'autoshape
    $txtFrm = $aShp->getTextFrame();
    # Rimuove il paragrafo predefinito
    $txtFrm->getParagraphs()->removeAt(0);
    # Crea un paragrafo
    $para = new Paragraph();
    # Imposta lo stile del punto elenco del paragrafo e il simbolo
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Imposta il testo del paragrafo
    $para->setText("Welcome to Aspose.Slides");
    # Imposta l'indentazione del punto elenco
    $para->getParagraphFormat()->setIndent(25);
    # Imposta il colore del punto elenco
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// imposta IsBulletHardColor a true per usare il proprio colore del punto elenco

    # Imposta l'altezza del punto elenco
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Aggiunge il paragrafo al TextFrame
    $txtFrm->getParagraphs()->add($para);
    # Crea il secondo paragrafo
    $para2 = new Paragraph();
    # Imposta il tipo e lo stile del punto elenco del paragrafo
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Aggiunge il testo al paragrafo
    $para2->setText("This is numbered bullet");
    # Imposta l'indentazione del punto elenco
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// imposta IsBulletHardColor a true per usare il proprio colore del punto elenco

    # Imposta l'altezza del punto elenco
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Aggiunge il paragrafo al TextFrame
    $txtFrm->getParagraphs()->add($para2);
    # Salva la presentazione modificata
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Gestire i punti elenco con immagine**

Le liste puntate aiutano a organizzare e presentare le informazioni in modo rapido ed efficiente. I paragrafi con immagine sono facili da leggere e comprendere.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Accedere al riferimento della diapositiva desiderata tramite il suo indice.
3. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
4. Accedere al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) dell'autoshape.
5. Rimuovere il paragrafo predefinito nel `TextFrame`.
6. Creare la prima istanza di paragrafo usando la classe [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/).
7. Caricare l'immagine in [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/).
8. Impostare il tipo di punto elenco su [Picture](https://reference.aspose.com/slides/it/php-java/aspose.slides/bullettype/#Picture) e impostare l'immagine.
9. Impostare il `Text` del paragrafo.
10. Impostare l'`Indent` del paragrafo per il punto elenco.
11. Impostare un colore per il punto elenco.
12. Impostare un'altezza per il punto elenco.
13. Aggiungere il nuovo paragrafo alla collezione di paragrafi del `TextFrame`.
14. Aggiungere il secondo paragrafo e ripetere il processo basato sui passaggi precedenti.
15. Salvare la presentazione modificata.

Questo codice PHP mostra come aggiungere e gestire punti elenco con immagine:

```php
# Istanzia una classe Presentation che rappresenta un file PPTX
$presentation = new Presentation();
try {
    # Accede alla prima diapositiva
    $slide = $presentation->getSlides()->get_Item(0);
    # Istanzia l'immagine per i punti elenco
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Aggiunge e accede a Autoshape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accede al textframe dell'autoshape
    $textFrame = $autoShape->getTextFrame();
    # Rimuove il paragrafo predefinito
    $textFrame->getParagraphs()->removeAt(0);
    # Crea un nuovo paragrafo
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Imposta lo stile del punto elenco del paragrafo e l'immagine
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Imposta l'altezza del punto elenco
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Aggiunge il paragrafo al text frame
    $textFrame->getParagraphs()->add($paragraph);
    # Scrive la presentazione come file PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Scrive la presentazione come file PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Gestire i punti elenco multilevel**

Le liste puntate aiutano a organizzare e presentare le informazioni in modo rapido ed efficiente. I punti elenco multilevel sono facili da leggere e comprendere.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Accedere al riferimento della diapositiva desiderata tramite il suo indice.
3. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) nella nuova diapositiva.
4. Accedere al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) dell'autoshape.
5. Rimuovere il paragrafo predefinito nel `TextFrame`.
6. Creare la prima istanza di paragrafo attraverso la classe [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/) e impostare la profondità a 0.
7. Creare la seconda istanza di paragrafo attraverso la classe `Paragraph` e impostare la profondità a 1.
8. Creare la terza istanza di paragrafo attraverso la classe `Paragraph` e impostare la profondità a 2.
9. Creare la quarta istanza di paragrafo attraverso la classe `Paragraph` e impostare la profondità a 3.
10. Aggiungere i nuovi paragrafi alla collezione di paragrafi del `TextFrame`.
11. Salvare la presentazione modificata.

Questo codice PHP mostra come aggiungere e gestire punti elenco multilevel:

```php
# Istanzia una classe Presentation che rappresenta un file PPTX
$pres = new Presentation();
try {
    # Accede alla prima diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Aggiunge e accede a Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accede al riquadro di testo dell'autoshape creato
    $text = $aShp->addTextFrame("");
    # Pulisce il paragrafo predefinito
    $text->getParagraphs()->clear();
    # Aggiunge il primo paragrafo
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Imposta il livello del punto elenco
    $para1->getParagraphFormat()->setDepth(0);
    # Aggiunge il secondo paragrafo
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Imposta il livello del punto elenco
    $para2->getParagraphFormat()->setDepth(1);
    # Aggiunge il terzo paragrafo
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Imposta il livello del punto elenco
    $para3->getParagraphFormat()->setDepth(2);
    # Aggiunge il quarto paragrafo
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Imposta il livello del punto elenco
    $para4->getParagraphFormat()->setDepth(3);
    # Aggiunge i paragrafi alla collezione
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # Scrive la presentazione come file PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Gestire un paragrafo con un elenco numerato personalizzato**

La classe [BulletFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/) fornisce il metodo [setNumberedBulletStartWith](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) e altri che consentono di gestire paragrafi con numerazione o formattazione personalizzata.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Accedere alla diapositiva contenente il paragrafo.
3. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
4. Accedere al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) dell'autoshape.
5. Rimuovere il paragrafo predefinito nel `TextFrame`.
6. Creare la prima istanza di paragrafo attraverso la classe [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/) e impostare [NumberedBulletStartWith](https://reference.aspose.com/slides/it/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) a 2.
7. Creare la seconda istanza di paragrafo attraverso la classe `Paragraph` e impostare `NumberedBulletStartWith` a 3.
8. Creare la terza istanza di paragrafo attraverso la classe `Paragraph` e impostare `NumberedBulletStartWith` a 7.
9. Aggiungere i nuovi paragrafi alla collezione di paragrafi del `TextFrame`.
10. Salvare la presentazione modificata.

Questo codice PHP mostra come aggiungere e gestire paragrafi con numerazione o formattazione personalizzata:

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accede al riquadro di testo dell'autoshape creato
    $textFrame = $shape->getTextFrame();
    # Rimuove il paragrafo predefinito esistente
    $textFrame->getParagraphs()->removeAt(0);
    # Prima lista
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Impostare l'indentazione della prima riga per un paragrafo**

Utilizzare il metodo [ParagraphFormat::setIndent](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setindent/) per controllare l'indentazione della prima riga di un paragrafo. Questo metodo sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga verso destra, mentre le righe restanti rimangono allineate al corpo del paragrafo.

Utilizzare [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setmarginleft/) quando è necessario spostare l'intero paragrafo. Utilizzare [ParagraphFormat::setIndent](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setindent/) quando è necessario spostare solo la prima riga.

L'esempio riportato di seguito crea diversi paragrafi e applica valori di indentazione diversi per dimostrare come l'indentazione della prima riga influisce sul layout del paragrafo.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Accedere alla diapositiva target.
3. Aggiungere un rettangolare [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
4. Aggiungere un [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) vuoto alla forma e rimuovere il paragrafo predefinito.
5. Creare diversi paragrafi e impostare valori diversi di [Indent](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setindent/) per ciascuno.
6. Aggiungere i paragrafi al riquadro di testo.
7. Salvare la presentazione modificata.

Questo codice mostra come impostare l'indentazione di un paragrafo:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
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

![L'indentazione della prima riga dei paragrafi](first_line_indent.png)

## **Impostare un'indentazione a penzolante per un paragrafo**

Un'indentazione a penzolante è una disposizione del paragrafo in cui la prima riga inizia a sinistra rispetto alle righe rimanenti. In Aspose.Slides, è possibile creare questo effetto con il metodo [ParagraphFormat::setIndent](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setindent/). Impostare l'indentazione a un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

In pratica, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setmarginleft/) definisce la posizione sinistra del corpo del paragrafo, e [ParagraphFormat::setIndent](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setindent/) definisce la posizione della prima riga rispetto a quel margine. Per creare un'indentazione a penzolante, impostare un valore positivo di `MarginLeft` e un valore negativo di `Indent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le righe a capo devono essere allineate sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Accedere alla diapositiva target.
3. Aggiungere un rettangolare [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
4. Aggiungere un [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) vuoto alla forma e rimuovere il paragrafo predefinito.
5. Creare i paragrafi e impostare un valore positivo di [MarginLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setmarginleft/) per ciascuno.
6. Impostare un valore negativo di [Indent](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setindent/) per creare l'effetto di indentazione a penzolante.
7. Aggiungere i paragrafi al riquadro di testo.
8. Salvare la presentazione modificata.

Questo codice mostra come impostare un'indentazione a penzolante per un paragrafo:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
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

![L'indentazione a penzolante dei paragrafi](hanging_indent.png)

## **Gestire le proprietà di esecuzione del paragrafo finale**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
1. Ottenere il riferimento alla diapositiva contenente il paragrafo tramite la sua posizione.
1. Aggiungere un rettangolo [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Aggiungere un [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) con due paragrafi al rettangolo.
1. Impostare l'altezza del carattere e il tipo di carattere per i paragrafi.
1. Impostare le proprietà End per i paragrafi.
1. Scrivere la presentazione modificata come file PPTX.

Questo codice PHP mostra come impostare le proprietà End per i paragrafi in PowerPoint:

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Importare testo HTML nei paragrafi**

Aspose.Slides fornisce supporto avanzato per l'importazione di testo HTML nei paragrafi.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Accedere al riferimento della diapositiva desiderata tramite il suo indice.
3. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
4. Aggiungere e accedere al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) dell'AutoShape.
5. Rimuovere il paragrafo predefinito nel `TextFrame`.
6. Leggere il file HTML di origine in un TextReader.
7. Creare la prima istanza di paragrafo attraverso la classe [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/).
8. Aggiungere il contenuto del file HTML letto dal TextReader alla [ParagraphCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphcollection/) del TextFrame.
9. Salvare la presentazione modificata.

Questo codice PHP è un'implementazione dei passaggi per importare testi HTML nei paragrafi:

```php
# Crea un'istanza vuota di presentazione
$pres = new Presentation();
try {
    # Accede alla prima diapositiva predefinita della presentazione
    $slide = $pres->getSlides()->get_Item(0);
    # Aggiunge l'AutoShape per contenere il contenuto HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Aggiunge il text frame alla forma
    $ashape->addTextFrame("");
    # Cancella tutti i paragrafi nel text frame aggiunto
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Carica il file HTML usando lo stream reader
    $tr = new StreamReader("file.html");
    # Aggiunge il testo dallo stream reader HTML nel text frame
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Salva la presentazione
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Esportare il testo del paragrafo in HTML**

Aspose.Slides fornisce supporto avanzato per l'esportazione dei testi (contenuti nei paragrafi) in HTML.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e caricare la presentazione desiderata.
2. Accedere al riferimento della diapositiva desiderata tramite il suo indice.
3. Accedere alla forma contenente il testo da esportare in HTML.
4. Accedere al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) della forma.
5. Creare un'istanza di `StreamWriter` e aggiungere il nuovo file HTML.
6. Fornire un indice di partenza a StreamWriter ed esportare i paragrafi desiderati.

Questo codice PHP mostra come esportare i testi dei paragrafi di PowerPoint in HTML:

```php
# Carica il file di presentazione
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Accede alla prima diapositiva predefinita della presentazione
    $slide = $pres->getSlides()->get_Item(0);
    # Indice desiderato
    $index = 0;
    # Accede alla forma aggiunta
    $ashape = $slide->getShapes()->get_Item($index);
    # Crea il file HTML di output
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Estrae il primo paragrafo come HTML
    # Scrive i dati dei paragrafi in HTML fornendo l'indice di inizio del paragrafo e il numero totale di paragrafi da copiare
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Salvare un paragrafo come immagine**

In questa sezione, esploreremo due esempi che dimostrano come salvare un paragrafo di testo, rappresentato dalla classe [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/), come immagine. Entrambi gli esempi includono l'ottenimento dell'immagine di una forma contenente il paragrafo tramite i metodi `getImage` della classe [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/), il calcolo dei limiti del paragrafo all'interno della forma e l'esportazione come immagine bitmap. Questi approcci consentono di estrarre parti specifiche del testo da presentazioni PowerPoint e salvarle come immagini separate, utili in vari scenari.

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, dove la prima forma è una casella di testo contenente tre paragrafi.

![La casella di testo con tre paragrafi](paragraph_to_image_input.png)

**Esempio 1**

In questo esempio, otteniamo il secondo paragrafo come immagine. Per farlo, estraiamo l'immagine della forma dalla prima diapositiva della presentazione e calcoliamo i limiti del secondo paragrafo nel riquadro di testo della forma. Il paragrafo viene quindi ridisegnato su una nuova immagine bitmap, salvata in formato PNG. Questo metodo è particolarmente utile quando è necessario salvare un paragrafo specifico come immagine separata mantenendo le dimensioni e la formattazione esatte del testo.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Salva la forma in memoria come bitmap.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Crea un bitmap della forma da memoria.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Calcola i confini del secondo paragrafo.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Calcola le coordinate e le dimensioni per l'immagine di output (dimensione minima - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Ritaglia il bitmap della forma per ottenere solo il bitmap del paragrafo.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Il risultato:

![L'immagine del paragrafo](paragraph_to_image_output.png)

**Esempio 2**

In questo esempio, estendiamo l'approccio precedente aggiungendo fattori di scala all'immagine del paragrafo. La forma viene estratta dalla presentazione e salvata come immagine con un fattore di scala di `2`. Ciò consente di ottenere un'output a risoluzione più alta quando si esporta il paragrafo. I limiti del paragrafo vengono quindi calcolati tenendo conto della scala. La scalatura è particolarmente utile quando è necessaria un'immagine più dettagliata, ad esempio per materiali stampati di alta qualità.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Salva la forma in memoria come bitmap con scalatura.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Crea un bitmap della forma da memoria.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Calcola i confini del secondo paragrafo.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Calcola le coordinate e le dimensioni per l'immagine di output (dimensione minima - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Ritaglia il bitmap della forma per ottenere solo il bitmap del paragrafo.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Posso disabilitare completamente l'andamento del testo all'interno di un riquadro di testo?**

Sì. Utilizzare l'impostazione di avvolgimento del riquadro di testo ([setWrapText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/setwraptext/)) per disattivare l'avvolgimento in modo che le linee non vengano interrotte ai bordi del riquadro.

**Come posso ottenere i limiti esatti su diapositiva di uno specifico paragrafo?**

È possibile recuperare il rettangolo di delimitazione del paragrafo (e anche di una singola porzione) per conoscere la sua posizione e dimensione precise sulla diapositiva.

**Dove è controllato l'allineamento del paragrafo (sinistra/destra/centro/giustificato)?**

[Alignment](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setalignment/) è un'impostazione a livello di paragrafo in [ParagraphFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/); si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare la lingua di correzione ortografica solo per una parte del paragrafo (ad es. una parola)?**

Sì. La lingua è impostata a livello di porzione ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setLanguageId)), quindi più lingue possono coesistere all'interno dello stesso paragrafo.