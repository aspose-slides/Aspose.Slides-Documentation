---
title: Verwalten von Präsentations-Folienmastern in Java
linktitle: Folienmaster
type: docs
weight: 70
url: /de/java/slide-master/
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
- unbenutzte Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten Sie Folienmaster in Aspose.Slides für Java: Erstellen, Bearbeiten und Anwenden von Layouts, Designs und Platzhaltern auf PPT, PPTX und ODP mit prägnanten Java-Beispielen."
---

## **Was ist ein Folienmaster in PowerPoint**

Ein **Slide Master** ist eine Folienvorlage, die Layout, Stile, Thema, Schriftarten, Hintergrund und andere Eigenschaften für Folien in einer Präsentation definiert. Wenn Sie eine Präsentation (oder eine Reihe von Präsentationen) mit demselben Stil und derselben Vorlage für Ihr Unternehmen erstellen möchten, können Sie einen Folienmaster verwenden.  

Ein Folienmaster ist nützlich, weil er Ihnen ermöglicht, das Aussehen aller Präsentationsfolien gleichzeitig festzulegen und zu ändern. Aspose.Slides unterstützt den Folienmaster‑Mechanismus von PowerPoint.  

VBA ermöglicht ebenfalls die Manipulation eines Folienmasters und das Ausführen derselben in PowerPoint unterstützten Vorgänge: Hintergründe ändern, Formen hinzufügen, Layout anpassen usw. Aspose.Slides bietet flexible Mechanismen, um Folienmaster zu verwenden und Grundaufgaben damit auszuführen.  

Dies sind grundlegende Folienmaster‑Operationen:

- Erstellen oder **Slide Master**.
- Folienmaster auf Präsentationsfolien anwenden.
- Hintergrund des Folienmasters ändern. 
- Ein Bild, Platzhalter, SmartArt usw. zum Folienmaster hinzufügen.

Dies sind weiterführende Operationen, die Folienmaster betreffen: 

- Folienmaster vergleichen.
- Folienmaster zusammenführen.
- Mehrere Folienmaster anwenden.
- Folie mit Folienmaster in eine andere Präsentation kopieren.
- Doppelte Folienmaster in Präsentationen finden.
- Folienmaster als Standardansicht der Präsentation festlegen.

{{% alert color="primary" %}} 

Vielleicht möchten Sie Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) ausprobieren, da er eine Live‑Implementierung einiger hier beschriebener Kernprozesse bietet.

{{% /alert %}} 


## **Wie wird ein Folienmaster angewendet**

Bevor Sie mit einem Folienmaster arbeiten, sollten Sie verstehen, wie sie in Präsentationen verwendet und auf Folien angewendet werden. 

* Jede Präsentation besitzt standardmäßig mindestens einen Folienmaster. 
* Eine Präsentation kann mehrere Folienmaster enthalten. Sie können mehrere Folienmaster hinzufügen und sie verwenden, um verschiedene Teile einer Präsentation unterschiedlich zu gestalten. 

In **Aspose.Slides** wird ein Folienmaster durch den Typ [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) repräsentiert. 

Das Aspose.Slides‑[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Objekt enthält die [**getMasters**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--)‑Liste vom Typ [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), die eine Liste aller in einer Präsentation definierten Folienmaster enthält. 

Neben CRUD‑Operationen enthält das [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/)‑Interface diese nützlichen Methoden: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) und [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). Diese Methoden stammen von der grundlegenden Folienklon‑Funktion ab. Beim Arbeiten mit Folienmastern ermöglichen sie jedoch komplexere Setups. 

Wenn einer Präsentation eine neue Folie hinzugefügt wird, wird automatisch ein Folienmaster darauf angewendet. Standardmäßig wird der Folienmaster der vorherigen Folie ausgewählt. 

**Hinweis**: Präsentationsfolien werden in der [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--)‑Liste gespeichert, und jede neue Folie wird standardmäßig am Ende der Sammlung hinzugefügt. Enthält eine Präsentation nur einen Folienmaster, wird dieser Master für alle neuen Folien ausgewählt. Das ist der Grund, warum Sie den Folienmaster nicht für jede neue Folie separat definieren müssen.

Das Prinzip ist für PowerPoint und Aspose.Slides identisch. Beispiel: In PowerPoint können Sie am unteren Rand nach der letzten Folie klicken und eine neue Folie (mit dem Folienmaster der vorherigen Folie) wird erstellt:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides können Sie die gleiche Aufgabe mit der [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)‑Methode der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse ausführen.


## **Folienmaster in der Folienhierarchie**

Die Verwendung von Folienlayouts zusammen mit dem Folienmaster ermöglicht maximale Flexibilität. Ein Folienlayout erlaubt es Ihnen, alle selben Stile wie der Folienmaster (Hintergrund, Schriftarten, Formen usw.) festzulegen. Wenn jedoch mehrere Folienlayouts auf einem Folienmaster kombiniert werden, entsteht ein neuer Stil. Wenn Sie ein Folienlayout auf eine einzelne Folie anwenden, können Sie dessen Stil vom vom Folienmaster angewendeten Stil abändern.

Der Folienmaster steht über allen Setup‑Elementen: Folienmaster → Folienlayout → Folie:

![todo:image_alt_text](slide-master_2)



Jedes [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide)-Objekt besitzt die Eigenschaft [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) mit einer Liste von Folienlayouts. Ein [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide)-Typ hat die Eigenschaft [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) mit einem Verweis auf das auf die Folie angewendete Folienlayout. Die Interaktion zwischen einer Folie und dem Folienmaster erfolgt über ein Folienlayout.

{{% alert color="info" title="Hinweis" %}}

* In Aspose.Slides sind alle Folien‑Setups (Folienmaster, Folienlayout und die Folie selbst) tatsächlich Folienobjekte, die das [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide)‑Interface implementieren.
* Daher können Folienmaster und Folienlayout dieselben Eigenschaften implementieren und Sie müssen wissen, wie deren Werte auf ein [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide)‑Objekt angewendet werden. Der Folienmaster wird zuerst auf eine Folie angewendet und danach das Folienlayout. Beispiel: Haben sowohl Folienmaster als auch Folienlayout einen Hintergrundwert, erhält die Folie den Hintergrund des Folienlayouts.

{{% /alert %}}


## **Was ein Folienmaster enthält**

Um zu verstehen, wie ein Folienmaster geändert werden kann, müssen Sie seine Bestandteile kennen. Dies sind die Kern‑Eigenschaften des [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/):

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) – ermittelt/setzt den Folienhintergrund.
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) – ermittelt/setzt Textstile des Folienkörpers.
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) – ermittelt/setzt alle Formen des Folienmasters (Platzhalter, Bildrahmen usw.).
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) – ermittelt/setzt ActiveX‑Steuerelemente.
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) – ermittelt den Theme‑Manager.
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) – ermittelt den Header‑ und Footer‑Manager.

Methoden des Folienmasters:

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) – liefert alle Folien, die vom Folienmaster abhängen.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) – ermöglicht das Erstellen eines neuen Folienmasters basierend auf dem aktuellen Folienmaster und einem neuen Theme. Der neue Folienmaster wird anschließend auf alle abhängigen Folien angewendet.


## **Einen Folienmaster erhalten**

In PowerPoint kann man den Folienmaster über das Menü Ansicht → Folienmaster aufrufen:

![todo:image_alt_text](slide-master_3.jpg)



Mit Aspose.Slides können Sie einen Folienmaster folgendermaßen abrufen: 
```java
Presentation pres = new Presentation();
try {
    // Gibt Zugriff auf die Masterfolie der Präsentation
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


Das [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide)-Interface repräsentiert einen Folienmaster. Die Eigenschaft [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) (bezogen auf den Typ [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)) enthält eine Liste aller in der Präsentation definierten Folienmaster.


## **Ein Bild zu einem Folienmaster hinzufügen**

Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf allen Folien, die von diesem Master abhängen. 

Beispielsweise können Sie das Firmenlogo und einige Bilder auf den Folienmaster legen und dann zurück in den Folien‑Bearbeitungsmodus wechseln. Das Bild sollte auf jeder Folie sichtbar sein. 

![todo:image_alt_text](slide-master_4.png)

Sie können Bilder zu einem Folienmaster mit Aspose.Slides hinzufügen:
```java
Presentation pres = new Presentation();
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    pres.getMasters().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="Siehe auch" %}} 

Weitere Informationen zum Hinzufügen von Bildern zu einer Folie finden Sie im Artikel [Picture Frame](/slides/de/java/picture-frame/#create-picture-frame).

{{% /alert %}}


## **Einen Platzhalter zu einem Folienmaster hinzufügen**

Dies sind Standard‑Platzhalter auf einem Folienmaster: 

* Klick zum Bearbeiten des Master‑Titels
* Master‑Textstile bearbeiten
* Zweite Ebene
* Dritte Ebene 

Sie erscheinen ebenfalls auf den Folien, die auf dem Folienmaster basieren. Sie können diese Platzhalter auf dem Folienmaster bearbeiten und die Änderungen werden automatisch auf die Folien angewendet. 

In PowerPoint können Sie einen Platzhalter über den Pfad Folienmaster → Platzhalter einfügen hinzufügen:



![todo:image_alt_text](slide-master_5.png)



Betrachten wir ein komplexeres Beispiel für Platzhalter mit Aspose.Slides. Angenommen, eine Folie verwendet Platzhalter, die aus dem Folienmaster stammen:



![todo:image_alt_text](slide-master_6.png)



Wir wollen die Formatierung von Titel und Untertitel im Folienmaster wie folgt ändern:

![todo:image_alt_text](slide-master_7.png)



Zuerst holen wir den Inhalt des Titel‑Platzhalters aus dem Folienmaster‑Objekt und verwenden dann das Feld `PlaceHolder.FillFormat`:
```java
public static void main(String[] args) {
    Presentation pres = new Presentation();
    try {
        IMasterSlide master = pres.getMasters().get_Item(0);
        IAutoShape placeHolder = findPlaceholder(master, PlaceholderType.Title);
        placeHolder.getFillFormat().setFillType(FillType.Gradient);
        placeHolder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(0, new Color(255, 0, 0));
        placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(255, new Color(128, 0, 128));

        pres.save("pres.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
}

static IAutoShape findPlaceholder(IMasterSlide master, int type)
{
    for (IShape shape : master.getShapes())
    {
        IAutoShape autoShape = (IAutoShape) shape;
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


Der Titel‑Stil und die Formatierung ändern sich für alle Folien, die auf dem Folienmaster basieren:



![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Siehe auch" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/java/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/java/text-formatting/)

{{% /alert %}}


## **Den Hintergrund eines Folienmasters ändern**

Wenn Sie die Hintergrundfarbe einer Master‑Folien ändern, erhalten alle normalen Folien in der Präsentation die neue Farbe. Dieser Java‑Code demonstriert den Vorgang:
```java
Presentation pres = new Presentation();
try {
    IMasterSlide master = pres.getMasters().get_Item(0);
    master.getBackground().setType(BackgroundType.OwnBackground);
    master.getBackground().getFillFormat().setFillType(FillType.Solid);
    master.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="Siehe auch" %}} 

- [Presentation Background](https://docs.aspose.com/slides/java/presentation-background/)

- [Presentation Theme](https://docs.aspose.com/slides/java/presentation-theme/)

{{% /alert %}}

## **Einen Folienmaster in eine andere Präsentation klonen**

Um einen Folienmaster in eine andere Präsentation zu klonen, rufen Sie die [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)‑Methode der Zielpräsentation auf und übergeben ihr einen Folienmaster. Dieser Java‑Code zeigt, wie ein Folienmaster in eine andere Präsentation geklont wird:
```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```



## **Mehrere Folienmaster zu einer Präsentation hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen mehrerer Folienmaster und Folienlayouts zu einer beliebigen Präsentation. Damit können Sie Stile, Layouts und Formatierungsoptionen für Präsentationsfolien auf vielfältige Weise festlegen. 

In PowerPoint können Sie neue Folienmaster und Layouts (aus dem „Folienmaster‑Menü“) wie folgt hinzufügen:

![todo:image_alt_text](slide-master_9.jpg)

Mit Aspose.Slides können Sie einen neuen Folienmaster hinzufügen, indem Sie die [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)‑Methode aufrufen:
```java
// Fügt eine neue Masterfolie hinzu
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **Folienmaster vergleichen**

Ein Master‑Slide implementiert das [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide)-Interface, das die Methode [**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) enthält, die zum Vergleich von Folien verwendet werden kann. Sie liefert `true` für Master‑Slides, die in Struktur und statischem Inhalt identisch sind. 

Zwei Master‑Slides sind gleich, wenn ihre Formen, Stile, Texte, Animationen und andere Einstellungen usw. gleich sind. Der Vergleich berücksichtigt weder eindeutige Bezeichnerwerte (z. B. SlideId) noch dynamische Inhalte (z. B. aktuelles Datum in einem Datums‑Platzhalter).


## **Einen Folienmaster als Standardansicht der Präsentation festlegen**

Aspose.Slides ermöglicht es, einen Folienmaster als Standardansicht einer Präsentation festzulegen. Die Standardansicht ist das, was Sie zuerst sehen, wenn Sie eine Präsentation öffnen. 

Dieser Code zeigt, wie Sie in Java einen Folienmaster als Standardansicht einer Präsentation festlegen:
```java
// Instanziiert eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation presentation = new Presentation();
try {
    // Setzt die Standardansicht auf SlideMasterView
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // Speichert die Präsentation
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```



## **Unbenutzte Master‑Slides entfernen**

Aspose.Slides stellt die Methode [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (aus der [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)‑Klasse) bereit, um nicht mehr benötigte Master‑Slides zu löschen. Dieser Java‑Code zeigt, wie Sie einen Master‑Slide aus einer PowerPoint‑Präsentation entfernen:
```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```



## **FAQ**

**Was ist ein Folienmaster in PowerPoint?**

Ein Folienmaster ist eine Folienvorlage, die Layout, Stile, Themen, Schriftarten, Hintergrund und andere Eigenschaften für Folien in einer Präsentation definiert. Er ermöglicht es, das Aussehen aller Präsentationsfolien gleichzeitig festzulegen und zu ändern.  

**Wie wird ein Folienmaster in einer Präsentation angewendet?**

Jede Präsentation hat standardmäßig mindestens einen Folienmaster. Wenn eine neue Folie hinzugefügt wird, wird automatisch ein Folienmaster darauf angewendet, normalerweise der Master der vorherigen Folie. Eine Präsentation kann mehrere Folienmaster enthalten, um unterschiedliche Teile individuell zu gestalten.  

**Welche Elemente können in einem Folienmaster angepasst werden?**

Ein Folienmaster besteht aus mehreren Kern‑Eigenschaften, die angepasst werden können:

- **Background**: Folienhintergrund festlegen.
- **BodyStyle**: Textstile für den Folienkörper definieren.
- **Shapes**: Alle Formen auf dem Folienmaster verwalten, einschließlich Platzhaltern und Bildrahmen.
- **Controls**: ActiveX‑Steuerelemente handhaben.
- **ThemeManager**: Zugriff auf den Theme‑Manager.
- **HeaderFooterManager**: Header und Footer verwalten.  

**Wie kann ich ein Bild zu einem Folienmaster hinzufügen?**

Durch das Hinzufügen eines Bildes zu einem Folienmaster erscheint es auf allen Folien, die von diesem Master abhängen. Beispielsweise wird ein Firmenlogo, das auf dem Folienmaster platziert wird, auf jeder Folie der Präsentation angezeigt.  

**Wie stehen Folienmaster zu Folienlayouts?**

Folienlayouts arbeiten zusammen mit Folienmastern, um Flexibilität im Folien‑Design zu bieten. Während ein Folienmaster übergeordnete Stile und Themen definiert, ermöglichen Folienlayouts Variationen in der Anordnung des Inhalts. Die Hierarchie lautet:

- **Folienmaster** → Definiert globale Stile.
- **Folienlayout** → Bietet verschiedene Inhaltsanordnungen.
- **Folie** → Erbt das Design von ihrem Folienlayout.

**Kann ich mehrere Folienmaster in einer einzelnen Präsentation haben?**

Ja, eine Präsentation kann mehrere Folienmaster enthalten. Dadurch können Sie verschiedene Abschnitte einer Präsentation auf unterschiedliche Weise gestalten und erhalten mehr Design‑Flexibilität.  

**Wie greife ich in Aspose.Slides auf einen Folienmaster zu und ändere ihn?**

In Aspose.Slides wird ein Folienmaster durch das [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/)‑Interface repräsentiert. Sie können einen Folienmaster über die [getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--)‑Methode des [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Objekts abrufen.