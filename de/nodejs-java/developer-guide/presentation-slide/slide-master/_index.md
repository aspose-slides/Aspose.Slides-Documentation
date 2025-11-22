---
title: Folienmaster
type: docs
weight: 70
url: /de/nodejs-java/slide-master/
keywords: "Folienmaster hinzufügen, PPT-Masterfolie, Slide Master PowerPoint, Bild zum Folienmaster, Platzhalter, mehrere Folienmaster, Folienmaster vergleichen, Java, Aspose.Slides für Node.js via Java"
description: "Folienmaster in PowerPoint-Präsentation in JavaScript hinzufügen oder bearbeiten"
---

## **Was ist ein Slide Master in PowerPoint**

Ein **Slide Master** ist eine Folienvorlage, die Layout, Stile, Design, Schriftarten, Hintergrund und andere Eigenschaften für Folien in einer Präsentation definiert. Wenn Sie eine Präsentation (oder eine Reihe von Präsentationen) mit dem gleichen Stil und der gleichen Vorlage für Ihr Unternehmen erstellen möchten, können Sie einen Slide Master verwenden. 

Ein Slide Master ist nützlich, weil er es ermöglicht, das Aussehen aller Präsentationsfolien auf einmal festzulegen und zu ändern. Aspose.Slides unterstützt den Slide Master‑Mechanismus von PowerPoint. 

VBA ermöglicht ebenfalls die Manipulation eines Slide Masters und das Ausführen der gleichen in PowerPoint unterstützten Vorgänge: Hintergründe ändern, Formen hinzufügen, Layout anpassen usw. Aspose.Slides bietet flexible Mechanismen, um Slide Masters zu nutzen und grundlegende Aufgaben damit auszuführen. 

Dies sind grundlegende Slide Master‑Operationen:

- Slide Master erstellen.
- Slide Master auf Präsentationsfolien anwenden.
- Slide Master‑Hintergrund ändern. 
- Ein Bild, Platzhalter, SmartArt usw. zum Slide Master hinzufügen.

Dies sind fortgeschrittenere Operationen mit Slide Master: 

- Slide Masters vergleichen.
- Slide Masters zusammenführen.
- Mehrere Slide Masters anwenden.
- Folie mit Slide Master in eine andere Präsentation kopieren.
- Duplizierte Slide Masters in Präsentationen finden.
- Slide Master als Standardansicht der Präsentation festlegen.

{{% alert color="primary" %}} 

Vielleicht möchten Sie Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) ausprobieren, da er eine Live‑Implementierung einiger der hier beschriebenen Kernprozesse ist.

{{% /alert %}} 


## **Wie wird ein Slide Master angewendet**

Bevor Sie mit einem Slide Master arbeiten, möchten Sie vielleicht verstehen, wie sie in Präsentationen verwendet und auf Folien angewendet werden. 

* Jede Präsentation hat standardmäßig mindestens einen Slide Master. 
* Eine Präsentation kann mehrere Slide Masters enthalten. Sie können mehrere Slide Masters hinzufügen und sie verwenden, um verschiedene Teile einer Präsentation auf unterschiedliche Weise zu gestalten. 

In **Aspose.Slides** wird ein Slide Master durch den Typ [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) dargestellt.

Das [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Objekt von Aspose.Slides enthält die [**getMasters**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters--)‑Liste des Typs [**MasterSlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), die eine Liste aller Masterfolien enthält, die in einer Präsentation definiert sind.

Zusätzlich zu CRUD‑Operationen enthält die Klasse [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) nützliche Methoden: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/#addClone-aspose.slides.ILayoutSlide-) und [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/#insertClone-int-aspose.slides.IMasterSlide-) . Diese Methoden werden von der grundlegenden Folienklonfunktion geerbt. Beim Umgang mit Slide Masters ermöglichen diese Methoden jedoch, komplexe Setups zu implementieren.

Wenn einer Präsentation eine neue Folie hinzugefügt wird, wird automatisch ein Slide Master darauf angewendet. Der Slide Master der vorherigen Folie wird standardmäßig ausgewählt. 

**Hinweis**: Präsentationsfolien werden in der [getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides--)‑Liste gespeichert, und jede neue Folie wird standardmäßig am Ende der Sammlung hinzugefügt. Wenn eine Präsentation einen einzigen Slide Master enthält, wird dieser Slide Master für alle neuen Folien ausgewählt. Das ist der Grund, warum Sie den Slide Master nicht für jede neu erstellte Folie definieren müssen.

Das Prinzip ist für PowerPoint und Aspose.Slides identisch. Zum Beispiel können Sie in PowerPoint, wenn Sie eine neue Folie hinzufügen, einfach auf die untere Linie unter der letzten Folie klicken und es wird eine neue Folie (mit dem Slide Master der letzten Präsentation) erstellt:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides können Sie die gleichwertige Aufgabe mit der Methode [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) unter der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse ausführen.


## **Slide Master in der Folienhierarchie**

Die Verwendung von Folienlayouts mit Slide Master ermöglicht maximale Flexibilität. Ein Folienlayout erlaubt es Ihnen, dieselben Stile wie beim Slide Master (Hintergrund, Schriftarten, Formen usw.) festzulegen. Wenn jedoch mehrere Folienlayouts auf einem Slide Master kombiniert werden, entsteht ein neuer Stil. Wenn Sie ein Folienlayout auf eine einzelne Folie anwenden, können Sie dessen Stil von dem des Slide Masters abändern.

Slide Master hat Vorrang vor allen Setup‑Elementen: Slide Master -> Folienlayout -> Folie:

![todo:image_alt_text](slide-master_2)



Jedes [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide)‑Objekt verfügt über die Eigenschaft [**getLayoutSlides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getLayoutSlides--) , die eine Liste von Folienlayouts enthält. Ein [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide)‑Typ hat die Eigenschaft [**getLayoutSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getLayoutSlide--) , die einen Verweis auf das auf die Folie angewendete Folienlayout enthält. Die Interaktion zwischen einer Folie und dem Slide Master erfolgt über ein Folienlayout.

{{% alert color="info" title="Note" %}}

* In Aspose.Slides sind alle Folieneinrichtungen (Slide Master, Folienlayout und die Folie selbst) tatsächlich Folienobjekte, die die Klasse [**BaseSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) implementieren.
* Daher können Slide Master und Folienlayout dieselben Eigenschaften implementieren und Sie müssen wissen, wie deren Werte auf ein [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide)‑Objekt angewendet werden. Der Slide Master wird zuerst auf eine Folie angewendet und dann das Folienlayout. Beispiel: Wenn Slide Master und Folienlayout beide einen Hintergrundwert haben, wird die Folie den Hintergrund des Folienlayouts erhalten.

{{% /alert %}}


## **Was ein Slide Master umfasst**

Um zu verstehen, wie ein Slide Master geändert werden kann, müssen Sie seine Bestandteile kennen. Dies sind die Kern‑Eigenschaften des [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/)‑Objekts.

- [getBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getBackground--) : Hintergrund der Folie holen/setzen.
- [getBodyStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getBodyStyle--) : Textstile des Folienkörpers holen/setzen.
- [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getShapes--) : Alle Formen des Slide Masters (Platzhalter, Bildrahmen usw.) holen/setzen.
- [getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getControls--) : ActiveX‑Steuerelemente holen/setzen.
- [getThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterThemeable#getThemeManager--) : Theme‑Manager holen.
- [getHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getHeaderFooterManager--) : Header‑ und Footer‑Manager holen.

Slide Master‑Methoden:

- [getDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getDependingSlides--) : Alle Folien, die vom Slide Master abhängen, holen.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) : Ermöglicht das Erstellen eines neuen Slide Masters basierend auf dem aktuellen Slide Master und einem neuen Theme. Der neue Slide Master wird dann auf alle abhängigen Folien angewendet.


## **Slide Master abrufen**

In PowerPoint kann der Slide Master über das Menü Ansicht -> Slide Master aufgerufen werden:

![todo:image_alt_text](slide-master_3.jpg)



Mit Aspose.Slides können Sie einen Slide Master wie folgt aufrufen: 
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Gibt Zugriff auf die Masterfolie der Präsentation
    var masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


Die Klasse [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) repräsentiert einen Slide Master. Die Eigenschaft [Masters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getMasters--) (bezogen auf den Typ [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection)) enthält eine Liste aller Slide Masters, die in der Präsentation definiert sind. 


## **Bild zu Slide Master hinzufügen**

Wenn Sie ein Bild zu einem Slide Master hinzufügen, erscheint dieses Bild auf allen Folien, die von diesem Slide Master abhängen. 

Zum Beispiel können Sie das Firmenlogo und einige Bilder auf dem Slide Master platzieren und dann zurück in den Folienbearbeitungsmodus wechseln. Das Bild sollte auf jeder Folie sichtbar sein. 

![todo:image_alt_text](slide-master_4.png)

Sie können mit Aspose.Slides Bilder zu einem Slide Master hinzufügen:
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


{{% alert color="primary" title="See also" %}} 

Weitere Informationen zum Hinzufügen von Bildern zu einer Folie finden Sie im Artikel [Picture Frame](/slides/de/nodejs-java/picture-frame/#create-picture-frame).

{{% /alert %}}


## **Platzhalter zum Slide Master hinzufügen**

Diese Textfelder sind standardmäßige Platzhalter auf einem Slide Master: 

* Klicken, um den Titelstil des Masters zu bearbeiten
* Master-Textstile bearbeiten
* Zweite Ebene
* Dritte Ebene 

Sie erscheinen auch auf den Folien, die auf dem Slide Master basieren. Sie können diese Platzhalter auf einem Slide Master bearbeiten und die Änderungen werden automatisch auf die Folien angewendet. 

In PowerPoint können Sie über den Pfad Slide Master -> Platzhalter einfügen einen Platzhalter hinzufügen:

![todo:image_alt_text](slide-master_5.png)

Betrachten wir ein komplizierteres Beispiel für Platzhalter mit Aspose.Slides. Betrachten Sie eine Folie mit Platzhaltern, die vom Slide Master vorlagen:

![todo:image_alt_text](slide-master_6.png)

Wir möchten die Formatierung von Titel und Untertitel auf dem Slide Master wie folgt ändern:

![todo:image_alt_text](slide-master_7.png)

Zuerst rufen wir den Inhalt des Titelplatzhalters aus dem Slide Master‑Objekt ab und verwenden dann das Feld `PlaceHolder.FillFormat`:
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


Der Titelstil und die Formatierung werden für alle Folien, die auf dem Slide Master basieren, geändert:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 

* [Prompt-Text im Platzhalter festlegen](https://docs.aspose.com/slides/nodejs-java/manage-placeholder/)
* [Textformatierung](https://docs.aspose.com/slides/nodejs-java/text-formatting/)

{{% /alert %}}


## **Hintergrund des Slide Masters ändern**

Wenn Sie die Hintergrundfarbe einer Masterfolie ändern, erhalten alle normalen Folien in der Präsentation die neue Farbe. Dieser JavaScript‑Code demonstriert den Vorgang:
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


{{% alert color="primary" title="See also" %}} 

- [Präsentationshintergrund](https://docs.aspose.com/slides/nodejs-java/presentation-background/)
- [Präsentationsthema](https://docs.aspose.com/slides/nodejs-java/presentation-theme/)

{{% /alert %}}

## **Slide Master in andere Präsentation klonen**

Um einen Slide Master in eine andere Präsentation zu klonen, rufen Sie die Methode [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) der Zielpräsentation auf und übergeben einen Slide Master. Dieser JavaScript‑Code zeigt, wie ein Slide Master in eine andere Präsentation geklont wird:
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



## **Mehrere Slide Masters zur Präsentation hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen mehrerer Slide Masters und Folienlayouts zu einer beliebigen Präsentation. Damit können Sie Stile, Layouts und Formatierungsoptionen für Präsentationsfolien auf vielfältige Weise festlegen. 

In PowerPoint können Sie neue Slide Masters und Layouts (aus dem „Slide Master“-Menü) wie folgt hinzufügen:

![todo:image_alt_text](slide-master_9.jpg)

Mit Aspose.Slides können Sie einen neuen Slide Master hinzufügen, indem Sie die Methode [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) aufrufen:
```javascript
// Fügt eine neue Masterfolie hinzu
var secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **Slide Masters vergleichen**

Ein Master Slide implementiert die Klasse [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide), die die Methode [**equals**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#equals-aspose.slides.IBaseSlide-) enthält, die zum Vergleich von Folien verwendet werden kann. Sie gibt `true` zurück, wenn Master Slides in Struktur und statischem Inhalt identisch sind.

Zwei Master Slides sind gleich, wenn ihre Formen, Stile, Texte, Animationen und andere Einstellungen usw. gleich sind. Der Vergleich berücksichtigt nicht eindeutige Kennungswerte (z. B. SlideId) und dynamische Inhalte (z. B. aktuelles Datum in einem Datumsplatzhalter). 


## **Slide Master als Standardansicht der Präsentation festlegen**

Aspose.Slides ermöglicht es, einen Slide Master als Standardansicht für eine Präsentation festzulegen. Die Standardansicht ist das, was Sie zuerst sehen, wenn Sie eine Präsentation öffnen. 

Dieser Code zeigt, wie Sie einen Slide Master in JavaScript als Standardansicht einer Präsentation festlegen:
```javascript
// Instanziiert eine Presentation‑Klasse, die die Präsentationsdatei repräsentiert
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



## **Unbenutzte Masterfolien entfernen**

Aspose.Slides stellt die Methode [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (aus der Klasse [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)) bereit, um nicht benötigte und unbenutzte Masterfolien zu löschen. Dieser JavaScript‑Code zeigt, wie Sie eine Masterfolie aus einer PowerPoint‑Präsentation entfernen:
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

**Was ist ein Slide Master in PowerPoint?**

Ein Slide Master ist eine Folienvorlage, die Layout, Stile, Designs, Schriftarten, Hintergrund und weitere Eigenschaften für Folien in einer Präsentation definiert. Sie ermöglicht es, das Aussehen aller Präsentationsfolien auf einmal festzulegen und zu ändern.  

**Wie wird ein Slide Master in einer Präsentation angewendet?**

Jede Präsentation hat standardmäßig mindestens einen Slide Master. Wenn eine neue Folie hinzugefügt wird, wird automatisch ein Slide Master darauf angewendet, in der Regel der Master der vorherigen Folie. Eine Präsentation kann mehrere Slide Masters enthalten, um verschiedene Teile individuell zu gestalten.  

**Welche Elemente können in einem Slide Master angepasst werden?**

Ein Slide Master besteht aus mehreren Kern‑Eigenschaften, die angepasst werden können:

- **Background**: Folienhintergrund festlegen.
- **BodyStyle**: Textstile für den Folienkörper definieren.
- **Shapes**: Alle Formen auf dem Slide Master verwalten, einschließlich Platzhaltern und Bildrahmen.
- **Controls**: ActiveX‑Steuerelemente verwalten.
- **ThemeManager**: Zugriff auf den Theme‑Manager.
- **HeaderFooterManager**: Header‑ und Footer‑Manager verwalten.  

**Wie kann ich ein Bild zu einem Slide Master hinzufügen?**

Wenn Sie ein Bild zu einem Slide Master hinzufügen, erscheint es auf allen Folien, die von diesem Master abhängen. Beispielsweise wird das Firmenlogo auf dem Slide Master auf jeder Folie der Präsentation angezeigt.  

**Wie hängen Slide Masters mit Folienlayouts zusammen?**

Folienlayouts arbeiten zusammen mit Slide Masters, um Flexibilität im Foliendesign zu bieten. Während ein Slide Master übergeordnete Stile und Designs definiert, ermöglichen Folienlayouts Variationen in der Anordnung des Inhalts. Die Hierarchie sieht folgendermaßen aus:

- **Slide Master** → Definiert globale Stile.
- **Slide Layout** → Bietet verschiedene Inhaltsanordnungen.
- **Slide** → Erbt das Design von seinem Folienlayout.  

**Kann ich mehrere Slide Masters in einer einzigen Präsentation haben?**

Ja, eine Präsentation kann mehrere Slide Masters enthalten. Damit können Sie verschiedene Abschnitte einer Präsentation auf unterschiedliche Weise gestalten und erhalten Flexibilität im Design.  

**Wie greife ich mit Aspose.Slides auf einen Slide Master zu und modifiziere ihn?**

In Aspose.Slides wird ein Slide Master durch die Klasse [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) repräsentiert. Sie können einen Slide Master über die Methode [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmasters/) des [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Objekts abrufen.