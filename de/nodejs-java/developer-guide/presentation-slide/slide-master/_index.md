---
title: Verwalten von Folienmastern in Präsentationen mit JavaScript
linktitle: Folienmaster
type: docs
weight: 70
url: /de/nodejs-java/slide-master/
keywords:
- Folienmaster
- Masterfolie
- PPT-Masterfolie
- mehrere Masterfolien
- Masterfolien vergleichen
- Hintergrund
- Platzhalter
- Masterfolie klonen
- Masterfolie kopieren
- Masterfolie duplizieren
- ungenutzte Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten Sie Folienmaster in Aspose.Slides für Node.js via Java: Erstellen, bearbeiten und anwenden von Layouts, Designs und Platzhaltern für PPT, PPTX und ODP mit prägnanten Beispielen."
---

## **Was ist ein Folienmaster in PowerPoint**

Ein **Slide Master** ist eine Folienvorlage, die Layout, Stile, Design, Schriftarten, Hintergrund und weitere Eigenschaften für Folien in einer Präsentation definiert. Wenn Sie eine Präsentation (oder Reihe von Präsentationen) mit demselben Stil und derselben Vorlage für Ihr Unternehmen erstellen möchten, können Sie einen Folienmaster verwenden. 

Ein Folienmaster ist nützlich, weil er es Ihnen ermöglicht, das Aussehen aller Präsentationsfolien auf einmal festzulegen und zu ändern. Aspose.Slides unterstützt den Folienmaster‑Mechanismus aus PowerPoint. 

VBA ermöglicht ebenfalls die Manipulation eines Folienmasters und die Ausführung derselben in PowerPoint unterstützten Vorgänge: Hintergründe ändern, Formen hinzufügen, Layout anpassen usw. Aspose.Slides bietet flexible Mechanismen, um Folienmaster zu verwenden und grundlegende Aufgaben damit auszuführen. 

Dies sind grundlegende Folienmaster‑Operationen:

- Erstellen eines Folienmasters.
- Folienmaster auf Präsentationsfolien anwenden.
- Hintergrund des Folienmasters ändern. 
- Ein Bild, Platzhalter, SmartArt usw. zum Folienmaster hinzufügen.

Dies sind fortgeschrittenere Vorgänge, die Folienmaster betreffen: 

- Folienmaster vergleichen.
- Folienmaster zusammenführen.
- Mehrere Folienmaster anwenden.
- Folie mit Folienmaster in eine andere Präsentation kopieren.
- Doppelte Folienmaster in Präsentationen finden.
- Folienmaster als Standardansicht der Präsentation festlegen.

{{% alert color="primary" %}} 

Vielleicht möchten Sie sich den Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) ansehen, da er eine Live‑Implementierung einiger der hier beschriebenen Kernprozesse darstellt.

{{% /alert %}} 


## **Wie wird ein Folienmaster angewendet**

Bevor Sie mit einem Folienmaster arbeiten, sollten Sie verstehen, wie er in Präsentationen verwendet und auf Folien angewendet wird. 

* Jede Präsentation hat standardmäßig mindestens einen Folienmaster. 
* Eine Präsentation kann mehrere Folienmaster enthalten. Sie können mehrere Folienmaster hinzufügen und sie verwenden, um verschiedene Teile einer Präsentation auf unterschiedliche Weise zu gestalten. 

In **Aspose.Slides** wird ein Folienmaster durch den Typ [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) dargestellt.

Das Aspose.Slides‑[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)-Objekt enthält die [**getMasters**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters--)‑Liste des Typs [**MasterSlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), die eine Liste aller in einer Präsentation definierten Master‑Folien enthält.

Neben CRUD‑Operationen enthält die Klasse [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) nützliche Methoden: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/#addClone-aspose.slides.ILayoutSlide-) und [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/#insertClone-int-aspose.slides.IMasterSlide-). Diese Methoden sind von der grundlegenden Folien‑Klon‑Funktion geerbt. Beim Umgang mit Folienmastern ermöglichen sie jedoch komplizierte Setups.

Wenn einer Präsentation eine neue Folie hinzugefügt wird, wird automatisch ein Folienmaster darauf angewendet. Der Folienmaster der vorherigen Folie wird standardmäßig ausgewählt. 

**Hinweis**: Präsentationsfolien werden in der [getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides--)‑Liste gespeichert, und jede neue Folie wird standardmäßig am Ende der Sammlung eingefügt. Enthält eine Präsentation nur einen Folienmaster, wird dieser Master für alle neuen Folien verwendet. Das ist der Grund, warum Sie den Folienmaster nicht für jede neu erstellte Folie festlegen müssen.

Das Prinzip ist für PowerPoint und Aspose.Slides identisch. In PowerPoint können Sie beispielsweise einfach auf die untere Linie unter der letzten Folie klicken, und eine neue Folie (mit dem Folienmaster der letzten Präsentation) wird erstellt:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides können Sie die äquivalente Aufgabe mit der [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-)‑Methode der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)-Klasse ausführen.


## **Folienmaster in der Folienhierarchie**

Die Verwendung von Folienlayouts zusammen mit dem Folienmaster ermöglicht maximale Flexibilität. Ein Folienlayout erlaubt es Ihnen, dieselben Stile wie beim Folienmaster (Hintergrund, Schriftarten, Formen usw.) festzulegen. Wenn mehrere Folienlayouts auf einem Folienmaster kombiniert werden, entsteht ein neuer Stil. Wenn Sie ein Folienlayout auf eine einzelne Folie anwenden, können Sie dessen Stil vom vom Folienmaster festgelegten Stil abweichen.

Der Folienmaster hat Vorrang vor allen Setup‑Elementen: Folienmaster → Folienlayout → Folie:

![todo:image_alt_text](slide-master_2)



Jedes [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide)-Objekt besitzt die Eigenschaft [**getLayoutSlides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getLayoutSlides--) mit einer Liste von Folienlayouts. Ein [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide)-Typ hat die Eigenschaft [**getLayoutSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getLayoutSlide--) mit einem Verweis auf das auf die Folie angewendete Folienlayout. Die Interaktion zwischen einer Folie und dem Folienmaster erfolgt über ein Folienlayout.

{{% alert color="info" title="Hinweis" %}}

* In Aspose.Slides sind alle Folien‑Setups (Folienmaster, Folienlayout und die Folie selbst) tatsächlich Folienobjekte, die die Klasse [**BaseSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) implementieren.  
* Daher können Folienmaster und Folienlayout dieselben Eigenschaften implementieren, und Sie müssen wissen, wie deren Werte auf ein [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide)-Objekt angewendet werden. Der Folienmaster wird zuerst auf die Folie angewendet, danach das Folienlayout. Beispielsweise erhält die Folie bei gleichzeitig definiertem Hintergrund im Folienmaster und im Folienlayout den Hintergrund des Folienlayouts.

{{% /alert %}}


## **Was ein Folienmaster enthält**

Um zu verstehen, wie ein Folienmaster geändert werden kann, müssen Sie seine Bestandteile kennen. Dies sind die Kern‑Eigenschaften von [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/):

- [getBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getBackground--) – Erhält/legt den Folienhintergrund fest.  
- [getBodyStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getBodyStyle--) – Erhält/legt Textstile des Folienkörpers fest.  
- [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getShapes--) – Erhält/legt alle Formen des Folienmasters fest (Platzhalter, Bildrahmen usw.).  
- [getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getControls--) – Erhält/legt ActiveX‑Steuerelemente fest.  
- [getThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getThemeManager) – Erhält Theme‑Manager.  
- [getHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getHeaderFooterManager--) – Erhält Header‑ und Footer‑Manager.  

Methoden des Folienmasters:

- [getDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getDependingSlides--) – Erhält alle Folien, die vom Folienmaster abhängen.  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) – Ermöglicht das Erstellen eines neuen Folienmasters basierend auf dem aktuellen Folienmaster und einem neuen Design. Der neue Folienmaster wird dann auf alle abhängigen Folien angewendet.  


## **Folienmaster abrufen**

In PowerPoint kann der Folienmaster über das Menü Ansicht → Folienmaster aufgerufen werden:

![todo:image_alt_text](slide-master_3.jpg)



Mit Aspose.Slides können Sie einen Folienmaster wie folgt abrufen: 
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Gibt Zugriff auf die Masterfolie der Präsentation
    var masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


Die Klasse [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) repräsentiert einen Folienmaster. Die Eigenschaft [Masters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getMasters--) (bezogen auf den Typ [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection)) enthält eine Liste aller in der Präsentation definierten Folienmaster.  


## **Bild zum Folienmaster hinzufügen**

Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf allen Folien, die von diesem Master abhängen. 

Beispielsweise können Sie das Logo Ihres Unternehmens und einige Bilder auf dem Folienmaster platzieren und dann wieder in den Folien‑Bearbeitungsmodus wechseln. Das Bild sollte auf jeder Folie sichtbar sein. 

![todo:image_alt_text](slide-master_4.png)

Sie können mit Aspose.Slides Bilder zu einem Folienmaster hinzufügen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    pres.getMasters().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="Siehe auch" %}} 

Weitere Informationen zum Hinzufügen von Bildern zu einer Folie finden Sie im Artikel [Picture Frame](/slides/de/nodejs-java/picture-frame/#create-picture-frame).

{{% /alert %}}


## **Platzhalter zum Folienmaster hinzufügen**

Diese Textfelder sind Standard‑Platzhalter auf einem Folienmaster: 

* Auf Titelstil des Masters klicken zum Bearbeiten
* Textstile des Masters bearbeiten
* Zweite Ebene
* Dritte Ebene 

Sie erscheinen auch auf den Folien, die auf dem Folienmaster basieren. Sie können diese Platzhalter auf einem Folienmaster bearbeiten, und die Änderungen werden automatisch auf die Folien angewendet. 

In PowerPoint können Sie über den Pfad Folienmaster → Platzhalter einfügen einen Platzhalter hinzufügen:

![todo:image_alt_text](slide-master_5.png)

Betrachten wir ein komplexeres Beispiel für Platzhalter mit Aspose.Slides. Angenommen, eine Folie enthält Platzhalter, die vom Folienmaster stammen:

![todo:image_alt_text](slide-master_6.png)

Wir möchten die Formatierung von Titel und Untertitel auf dem Folienmaster wie folgt ändern:

![todo:image_alt_text](slide-master_7.png)

Zuerst lesen wir den Inhalt des Titel‑Platzhalters aus dem Folienmaster‑Objekt und verwenden dann das Feld `PlaceHolder.FillFormat`:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var master = pres.getMasters().get_Item(0);
    var placeHolder = findPlaceholder(master, aspose.slides.PlaceholderType.Title);
    placeHolder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    placeHolder.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    var awtColor = java.import('java.awt.Color');
    placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(0, java.newInstanceSync('java.awt.Color', 255, 0, 0));
    placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(255, java.newInstanceSync('java.awt.Color', 128, 0, 128));

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

function findPlaceholder(master, type)
{    
    for (var i = 0 ; i < master.getShapes().size(); i++)
    {
        var autoShape = master.getShapes().get_Item(i);
        if (autoShape != null)
        {
            if (autoShape.getPlaceholder().getType() == type)
            {
                return autoShape;
            }
        }
    }

    return null;
}
```


Der Titelstil und die Formatierung ändern sich für alle Folien, die auf dem Folienmaster basieren:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Siehe auch" %}} 

* [Prompt‑Text im Platzhalter festlegen](https://docs.aspose.com/slides/nodejs-java/manage-placeholder/)
* [Textformatierung](https://docs.aspose.com/slides/nodejs-java/text-formatting/)

{{% /alert %}}


## **Hintergrund des Folienmasters ändern**

Wenn Sie die Hintergrundfarbe einer Master‑Folie ändern, erhalten alle normalen Folien in der Präsentation die neue Farbe. Dieser JavaScript‑Code demonstriert den Vorgang:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var master = pres.getMasters().get_Item(0);
    master.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    master.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    master.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="Siehe auch" %}} 

- [Präsentationshintergrund](https://docs.aspose.com/slides/nodejs-java/presentation-background/)
- [Präsentationsdesign](https://docs.aspose.com/slides/nodejs-java/presentation-theme/)

{{% /alert %}}

## **Folienmaster in eine andere Präsentation klonen**

Um einen Folienmaster in eine andere Präsentation zu klonen, rufen Sie die [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-)‑Methode der Zielpräsentation auf und übergeben ihr einen Folienmaster. Dieser JavaScript‑Code zeigt, wie ein Folienmaster in eine andere Präsentation geklont wird:
```javascript
var presSource = new aspose.slides.Presentation();
var presTarget = new aspose.slides.Presentation();
try {
    var master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) {
        presSource.dispose();
    }
}
```



## **Mehrere Folienmaster zu einer Präsentation hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen mehrerer Folienmaster und Folienlayouts zu einer beliebigen Präsentation. Damit können Sie Stile, Layouts und Formatierungsoptionen für Präsentationsfolien auf vielfältige Weise festlegen. 

In PowerPoint können Sie neue Folienmaster und Layouts (aus dem „Folienmaster‑Menü“) wie folgt hinzufügen:

![todo:image_alt_text](slide-master_9.jpg)

Mit Aspose.Slides können Sie einen neuen Folienmaster hinzufügen, indem Sie die [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-)‑Methode aufrufen:
```javascript
// Fügt eine neue Masterfolie hinzu
var secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **Folienmaster vergleichen**

Ein Master‑Slide implementiert die Klasse [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) mit der Methode [**equals**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#equals-aspose.slides.IBaseSlide-), die zum Vergleichen von Folien verwendet werden kann. Sie gibt `true` zurück, wenn Master‑Slides in Struktur und statischem Inhalt identisch sind.

Zwei Master‑Slides gelten als gleich, wenn ihre Formen, Stile, Texte, Animationen und weitere Einstellungen gleich sind. Der Vergleich berücksichtigt keine eindeutigen Kennungen (z. B. SlideId) und keinen dynamischen Inhalt (z. B. aktuelles Datum in einem Datums‑Platzhalter). 


## **Folienmaster als Standardansicht der Präsentation festlegen**

Aspose.Slides ermöglicht das Festlegen eines Folienmasters als Standardansicht einer Präsentation. Die Standardansicht ist das, was Sie zuerst sehen, wenn Sie eine Präsentation öffnen. 

Dieser Code zeigt, wie ein Folienmaster in JavaScript als Standardansicht einer Präsentation festgelegt wird:
```javascript
// Instanziiert eine Presentation-Klasse, die die Präsentationsdatei darstellt
var presentation = new aspose.slides.Presentation();
try {
    // Setzt die Standardansicht auf SlideMasterView
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    // Speichert die Präsentation
    presentation.save("PresView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```



## **Unbenutzten Folienmaster entfernen**

Aspose.Slides stellt die Methode [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (aus der Klasse [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)) bereit, um unerwünschte und ungenutzte Master‑Folien zu löschen. Dieser JavaScript‑Code zeigt, wie ein Master‑Slide aus einer PowerPoint‑Präsentation entfernt wird:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Was ist ein Folienmaster in PowerPoint?**

Ein Folienmaster ist eine Folienvorlage, die Layout, Stile, Designs, Schriftarten, Hintergrund und weitere Eigenschaften für Folien in einer Präsentation definiert. Er ermöglicht es, das Aussehen aller Präsentationsfolien auf einmal festzulegen und zu ändern.  

**Wie wird ein Folienmaster in einer Präsentation angewendet?**

Jede Präsentation hat standardmäßig mindestens einen Folienmaster. Wenn eine neue Folie hinzugefügt wird, wird automatisch ein Folienmaster darauf angewendet, in der Regel der Master der vorherigen Folie. Eine Präsentation kann mehrere Folienmaster enthalten, um verschiedene Teile individuell zu gestalten.  

**Welche Elemente können in einem Folienmaster angepasst werden?**

Ein Folienmaster besteht aus mehreren Kern‑Eigenschaften, die angepasst werden können:

- **Background**: Folienhintergrund festlegen.  
- **BodyStyle**: Textstile des Folienkörpers definieren.  
- **Shapes**: Alle Formen auf dem Folienmaster verwalten, einschließlich Platzhaltern und Bildrahmen.  
- **Controls**: ActiveX‑Steuerelemente handhaben.  
- **ThemeManager**: Zugriff auf den Theme‑Manager.  
- **HeaderFooterManager**: Header‑ und Footer‑Manager verwalten.  

**Wie kann ich ein Bild zu einem Folienmaster hinzufügen?**

Durch das Hinzufügen eines Bildes zu einem Folienmaster erscheint es auf allen Folien, die von diesem Master abhängen. Beispielsweise wird das Firmenlogo, das Sie auf dem Folienmaster platzieren, auf jeder Folie der Präsentation angezeigt.  

**Wie stehen Folienmaster zu Folienlayouts?**

Folienlayouts arbeiten zusammen mit Folienmastern, um Flexibilität im Foliendesign zu bieten. Während ein Folienmaster übergeordnete Stile und Designs definiert, ermöglichen Folienlayouts Variationen in der Anordnung des Inhalts. Die Hierarchie lautet:

- **Folienmaster** → Definiert globale Stile.  
- **Folienlayout** → Bietet unterschiedliche Inhaltsanordnungen.  
- **Folie** → Erbt das Design vom zugeordneten Folienlayout.  

**Kann ich mehrere Folienmaster in einer einzelnen Präsentation haben?**

Ja, eine Präsentation kann mehrere Folienmaster enthalten. Dadurch können Sie verschiedene Abschnitte einer Präsentation auf unterschiedliche Weise gestalten und erhalten mehr Design‑Flexibilität.  

**Wie greife ich mit Aspose.Slides auf einen Folienmaster zu und ändere ihn?**

In Aspose.Slides wird ein Folienmaster durch die Klasse [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) repräsentiert. Sie können mit der Methode [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmasters/) des [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)-Objekts auf einen Folienmaster zugreifen.