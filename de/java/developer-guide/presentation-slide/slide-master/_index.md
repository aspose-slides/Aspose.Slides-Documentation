---
title: Folienmaster
type: docs
weight: 70
url: /java/slide-master/
keywords: "Folienmaster hinzufügen, PPT-Folienmaster, Folienmaster PowerPoint, Bild zu Folienmaster, Platzhalter, mehrere Folienmaster, Folienmaster vergleichen, Java, Aspose.Slides für Java"
description: "Fügen Sie einen Folienmaster in einer PowerPoint-Präsentation in Java hinzu oder bearbeiten Sie ihn"
---

## **Was ist ein Folienmaster in PowerPoint**

Ein **Folienmaster** ist eine Folienvorlage, die das Layout, Stile, Themen, Schriftarten, Hintergründe und andere Eigenschaften für Folien in einer Präsentation definiert. Wenn Sie eine Präsentation (oder eine Reihe von Präsentationen) im gleichen Stil und mit derselben Vorlage für Ihr Unternehmen erstellen möchten, können Sie einen Folienmaster verwenden.

Ein Folienmaster ist nützlich, weil er es Ihnen ermöglicht, das Erscheinungsbild aller Präsentationsfolien auf einmal festzulegen und zu ändern. Aspose.Slides unterstützt den Folienmaster-Mechanismus von PowerPoint.

VBA ermöglicht es Ihnen ebenfalls, einen Folienmaster zu manipulieren und die gleichen Operationen auszuführen, die in PowerPoint unterstützt werden: Hintergründe ändern, Formen hinzufügen, das Layout anpassen usw. Aspose.Slides bietet flexible Mechanismen, um Folienmaster zu verwenden und grundlegende Aufgaben mit ihnen auszuführen.

Dies sind grundlegende Operationen mit Folienmastern:

- Folienmaster erstellen oder bearbeiten.
- Folienmaster auf Präsentationsfolien anwenden.
- Hintergrund des Folienmasters ändern.
- Ein Bild, Platzhalter, Smart Art usw. zum Folienmaster hinzufügen.

Dies sind erweiterte Operationen mit Folienmastern:

- Folienmaster vergleichen.
- Folienmaster zusammenführen.
- Mehrere Folienmaster anwenden.
- Folie mit Folienmaster in eine andere Präsentation kopieren.
- Duplikate von Folienmastern in Präsentationen finden.
- Folienmaster als Standardansicht der Präsentation festlegen.

{{% alert color="primary" %}} 

Sie möchten möglicherweise Aspose [**Online PowerPoint-Viewer**](https://products.aspose.app/slides/viewer) ausprobieren, da dies eine Live-Implementierung einiger der hier beschriebenen Kernprozesse ist.

{{% /alert %}} 


## **Wie wird der Folienmaster angewendet**

Bevor Sie mit einem Folienmaster arbeiten, sollten Sie verstehen, wie sie in Präsentationen verwendet und auf Folien angewendet werden.

* Jede Präsentation hat standardmäßig mindestens einen Folienmaster.
* Eine Präsentation kann mehrere Folienmaster enthalten. Sie können mehrere Folienmaster hinzufügen und verwenden, um verschiedene Teile einer Präsentation unterschiedlich zu gestalten.

In **Aspose.Slides** wird ein Folienmaster durch den [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) Typ dargestellt.

Das [Präsentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Objekt von Aspose.Slides enthält die [**getMasters**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) Liste des Typs [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), die eine Liste aller Masterfolien enthält, die in einer Präsentation definiert sind.

Neben CRUD-Operationen enthält das [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) Interface diese nützlichen Methoden: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) und [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) Methoden. Diese Methoden sind von der grundlegenden Folienklonfunktion erben. Wenn Sie jedoch mit Folienmastern arbeiten, ermöglichen Ihnen diese Methoden die Implementierung komplizierter Setups.

Wenn eine neue Folie zu einer Präsentation hinzugefügt wird, wird automatisch ein Folienmaster darauf angewendet. Der Folienmaster der vorherigen Folie wird standardmäßig ausgewählt.

**Hinweis**: Präsentationsfolien werden in der [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) Liste gespeichert, und jede neue Folie wird standardmäßig am Ende der Sammlung hinzugefügt. Wenn eine Präsentation einen einzigen Folienmaster enthält, wird dieser Folienmaster für alle neuen Folien ausgewählt. Dies ist der Grund, warum Sie den Folienmaster nicht für jede neue Folie definieren müssen, die Sie erstellen.

Das Prinzip ist für PowerPoint und Aspose.Slides dasselbe. Zum Beispiel, wenn Sie in PowerPoint eine neue Präsentation hinzufügen, können Sie einfach auf die untere Linie unter der letzten Folie klicken und dann wird eine neue Folie (mit dem Folienmaster der letzten Präsentation) erstellt:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides können Sie die äquivalente Aufgabe mit der [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) Methode unter der [Präsentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse ausführen.


## **Folienmaster in der Folienhierarchie**

Die Verwendung von Folienlayouts mit Folienmaster ermöglicht maximale Flexibilität. Ein Folienlayout ermöglicht es Ihnen, all die gleichen Stile wie der Folienmaster (Hintergrund, Schriftarten, Formen usw.) festzulegen. Wenn mehrere Folienlayouts jedoch in einem Folienmaster kombiniert werden, wird ein neuer Stil erstellt. Wenn Sie einem einzelnen Folie ein Folienlayout anwenden, können Sie dessen Stil von dem, der vom Folienmaster angewendet wird, ändern.

Der Folienmaster hat Vorrang vor allen Setups: Folienmaster -> Folienlayout -> Folie:

![todo:image_alt_text](slide-master_2)



Jedes [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) Objekt hat eine [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) Eigenschaft mit einer Liste von Folienlayouts. Ein [Folien](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) Typ hat eine [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) Eigenschaft mit einem Link zu einem Folienlayout, das auf die Folie angewendet wird. Die Interaktion zwischen einer Folie und dem Folienmaster erfolgt über ein Folienlayout.

{{% alert color="info" title="Hinweis" %}}

* In Aspose.Slides sind alle Foliensetups (Folienmaster, Folienlayout und die Folie selbst) tatsächlich Folienobjekte, die das [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) Interface implementieren.
* Daher können Folienmaster und Folienlayout dieselben Eigenschaften implementieren und Sie müssen wissen, wie ihre Werte auf ein [Folie](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) Objekt angewendet werden. Der Folienmaster wird zuerst auf eine Folie angewendet und dann das Folienlayout. Wenn der Folienmaster und das Folienlayout beide einen Hintergrundwert haben, wird die Folie am Ende mit dem Hintergrund des Folienlayouts versehen.

{{% /alert %}}


## **Was ein Folienmaster umfasst**

Um zu verstehen, wie ein Folienmaster geändert werden kann, müssen Sie seine Bestandteile kennen. Dies sind die grundlegenden Eigenschaften von [MasterSlide](https://reference.aspose.com/slides/java/aspose.slides/masterslide/). 

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) Hintergrund der Folie abrufen/festlegen.
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) - Textstile des Folientextkörpers abrufen/festlegen.
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) alle Formen des Folienmasters abrufen/festlegen (Platzhalter, Bildrahmen usw.).
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) ActiveX-Steuerelemente abrufen/festlegen.
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) - Theme-Manager abrufen.
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) - Kopf- und Fußzeilenmanager abrufen.

Methoden des Folienmasters:

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) - alle Folien abrufen, die vom Folienmaster abhängig sind.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - ermöglicht es Ihnen, einen neuen Folienmaster basierend auf dem aktuellen Folienmaster und einem neuen Thema zu erstellen. Der neue Folienmaster wird dann auf alle abhängigen Folien angewendet.


## **Folienmaster abrufen**

In PowerPoint kann der Folienmaster über das Menü Ansicht -> Folienmaster aufgerufen werden:

![todo:image_alt_text](slide-master_3.jpg)



Mit Aspose.Slides können Sie auf einen Folienmaster folgendermaßen zugreifen: 

```java
Presentation pres = new Presentation();
try {
    // Zugriff auf den Master-Folien der Präsentation
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```

Das [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) Interface stellt einen Folienmaster dar. Die [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) Eigenschaft (die sich auf den Typ [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) bezieht) enthält eine Liste aller Folienmaster, die in der Präsentation definiert sind. 


## **Bild zu Folienmaster hinzufügen**

Wenn Sie ein Bild zu einem Folienmaster hinzufügen, wird dieses Bild auf allen Folien angezeigt, die von diesem Folienmaster abhängen. 

Beispielsweise können Sie das Firmenlogo und einige Bilder auf dem Folienmaster platzieren und dann zurück in den Folienbearbeitungsmodus wechseln. Sie sollten das Bild auf jeder Folie sehen. 

![todo:image_alt_text](slide-master_4.png)

Sie können Bilder mit Aspose.Slides zu einem Folienmaster hinzufügen:

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

Für weitere Informationen zum Hinzufügen von Bildern zu einer Folie siehe den Artikel [Bildrahmen](/slides/java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Platzhalter zu Folienmaster hinzufügen**

Diese Textfelder sind Standardplatzhalter auf einem Folienmaster: 

* Klicken Sie, um den Titelstil des Masters zu bearbeiten

* Master-Textstile bearbeiten

* Zweite Ebene

* Dritte Ebene 

  Sie erscheinen auch auf den Folien, die auf dem Folienmaster basieren. Sie können diese Platzhalter auf einem Folienmaster bearbeiten und die Änderungen werden automatisch auf die Folien angewendet. 

In PowerPoint können Sie einen Platzhalter über den Pfad Folienmaster -> Platzhalter einfügen hinzufügen:



![todo:image_alt_text](slide-master_5.png)



Betrachten wir ein komplizierteres Beispiel für Platzhalter mit Aspose.Slides. Betrachten Sie eine Folie mit Platzhaltern, die vom Folienmaster vorgegeben sind:



![todo:image_alt_text](slide-master_6.png)



Wir möchten die Titel- und Untertitelformatierung auf dem Folienmaster folgendermaßen ändern:

![todo:image_alt_text](slide-master_7.png)



Zuerst rufen wir den Inhalt des Titelplatzhalters vom Folienmasterobjekt ab und verwenden dann das`PlaceHolder.FillFormat` Feld: 

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

Der Titelstil und die Formatierung werden für alle Folien geändert, die auf dem Folienmaster basieren:



![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Siehe auch" %}} 

* [Platzhaltertext festlegen](https://docs.aspose.com/slides/java/manage-placeholder/)
* [Textformatierung](https://docs.aspose.com/slides/java/text-formatting/)

{{% /alert %}}


## **Hintergrund auf Folienmaster ändern**

Wenn Sie die Hintergrundfarbe eines Folienmasters ändern, erhalten alle normalen Folien in der Präsentation die neue Farbe. Dieser Java-Code demonstriert die Operation:

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

- [Präsentationshintergrund](https://docs.aspose.com/slides/java/presentation-background/)

- [Präsentationsthema](https://docs.aspose.com/slides/java/presentation-theme/)

  {{% /alert %}}

## **Folienmaster in eine andere Präsentation klonen**

Um einen Folienmaster in eine andere Präsentation zu klonen, rufen Sie die [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) Methode der Zielpräsentation zusammen mit einem Folienmaster auf, der an sie übergeben wird. Dieser Java-Code zeigt Ihnen, wie Sie einen Folienmaster in eine andere Präsentation klonen:

```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```


## **Mehrere Folienmaster zur Präsentation hinzufügen**

Aspose.Slides ermöglicht es Ihnen, mehrere Folienmaster und Folienlayouts zu einer beliebigen Präsentation hinzuzufügen. Dies ermöglicht es Ihnen, Stile, Layouts und Formatierungsoptionen für Präsentationsfolien auf viele Arten einzurichten.

In PowerPoint können Sie auf diese Weise neue Folienmaster und Layouts (aus dem Menü "Folienmaster") hinzufügen:

![todo:image_alt_text](slide-master_9.jpg)

Mit Aspose.Slides können Sie einen neuen Folienmaster hinzufügen, indem Sie die [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) Methode aufrufen:

```java
// Fügt einen neuen Master-Folien hinzu
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **Folienmaster vergleichen**

Ein Folienmaster implementiert das [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) Interface, das die [**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) Methode enthält, die verwendet werden kann, um Folien zu vergleichen. Es gibt `true` zurück für Folienmaster, die in Struktur und statischen Inhalten identisch sind.

Zwei Folienmaster sind gleich, wenn ihre Formen, Stile, Texte, Animationen und andere Einstellungen usw. gleich sind. Der Vergleich berücksichtigt keine eindeutigen Identifikatorwerte (z. B. SlideId) und dynamischen Inhalt (z. B. aktuellen Datumswert im Datumsplatzhalter). 


## **Folienmaster als Standardansicht der Präsentation festlegen**

Aspose.Slides ermöglicht es Ihnen, einen Folienmaster als Standardansicht für eine Präsentation festzulegen. Die Standardansicht ist das, was Sie zuerst sehen, wenn Sie eine Präsentation öffnen.

Dieser Code zeigt Ihnen, wie Sie einen Folienmaster als Standardansicht einer Präsentation in Java festlegen:

```java
// Instanziiert eine Präsentationsklasse, die die Präsentationsdatei darstellt
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

## **Unerwünschten Folienmaster entfernen**

Aspose.Slides bietet die [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) Methode (aus der [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) Klasse), um unerwünschte und unbenutzte Folienmaster zu löschen. Dieser Java-Code zeigt Ihnen, wie Sie einen Folienmaster aus einer PowerPoint-Präsentation entfernen:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```