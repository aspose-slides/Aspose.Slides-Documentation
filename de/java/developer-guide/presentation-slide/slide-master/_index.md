---
title: Verwalten von Folienmastern in Präsentationen in Java
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
description: "Verwalten von Folienmastern in Aspose.Slides für Java: Erstellen, Bearbeiten und Anwenden von Layouts, Designs und Platzhaltern auf PPT, PPTX und ODP mit prägnanten Java‑Beispielen."
---

## **Was ist ein Folienmaster in PowerPoint**

Ein **Folienmaster** ist eine Folienvorlage, die das Layout, die Stile, das Design, die Schriftarten, den Hintergrund und weitere Eigenschaften für Folien in einer Präsentation definiert. Wenn Sie eine Präsentation (oder eine Reihe von Präsentationen) mit demselben Stil und derselben Vorlage für Ihr Unternehmen erstellen möchten, können Sie einen Folienmaster verwenden.  

Ein Folienmaster ist nützlich, weil er es Ihnen ermöglicht, das Aussehen aller Präsentationsfolien gleichzeitig festzulegen und zu ändern. Aspose.Slides unterstützt den Folienmaster‑Mechanismus von PowerPoint.  

VBA ermöglicht ebenfalls die Manipulation eines Folienmasters und die Ausführung derselben Operationen, die in PowerPoint unterstützt werden: Hintergründe ändern, Formen hinzufügen, das Layout anpassen usw. Aspose.Slides bietet flexible Mechanismen, um Folienmaster zu verwenden und grundlegende Aufgaben damit auszuführen.  

Dies sind grundlegende Folienmaster‑Operationen:

- Einen Folienmaster erstellen.
- Folienmaster auf Präsentationsfolien anwenden.
- Hintergrund des Folienmasters ändern. 
- Ein Bild, Platzhalter, SmartArt usw. zum Folienmaster hinzufügen.

Dies sind weiterführende Operationen mit Folienmastern: 

- Folienmaster vergleichen.
- Folienmaster zusammenführen.
- Mehrere Folienmaster anwenden.
- Folie mit Folienmaster in eine andere Präsentation kopieren.
- Doppelte Folienmaster in Präsentationen finden.
- Folienmaster als Standardansicht der Präsentation festlegen.

{{% alert color="primary" %}} 

Vielleicht möchten Sie Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) ausprobieren, da er eine Live‑Implementierung einiger der hier beschriebenen Kernprozesse darstellt.

{{% /alert %}} 


## **Wie wird ein Folienmaster angewendet**

Bevor Sie mit einem Folienmaster arbeiten, sollten Sie verstehen, wie sie in Präsentationen verwendet und auf Folien angewendet werden. 

* Jede Präsentation hat standardmäßig mindestens einen Folienmaster. 
* Eine Präsentation kann mehrere Folienmaster enthalten. Sie können mehrere Folienmaster hinzufügen und sie verwenden, um verschiedene Teile einer Präsentation auf unterschiedliche Weise zu gestalten. 

In **Aspose.Slides** wird ein Folienmaster durch den [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/)‑Typ dargestellt. 

Das Aspose.Slides‑[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Objekt enthält die [**getMasters**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--)‑Liste von [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), die eine Liste aller in einer Präsentation definierten Folienmaster enthält. 

Neben CRUD‑Operationen enthält die [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/)‑Schnittstelle diese nützlichen Methoden: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) und [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). Diese Methoden stammen aus der grundlegenden Folienklon‑Funktion. Beim Umgang mit Folienmastern ermöglichen sie jedoch die Implementierung komplexer Setups. 

Wenn einer Präsentation eine neue Folie hinzugefügt wird, wird ihr automatisch ein Folienmaster zugewiesen. Standardmäßig wird der Folienmaster der vorherigen Folie übernommen. 

**Hinweis**: Präsentationsfolien werden in der [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--)‑Liste gespeichert, und jede neue Folie wird standardmäßig am Ende der Sammlung eingefügt. Enthält eine Präsentation nur einen Folienmaster, wird dieser für alle neuen Folien verwendet. Deshalb müssen Sie den Folienmaster nicht für jede neue Folie explizit festlegen.

Das Prinzip ist bei PowerPoint und Aspose.Slides identisch. Beispiel PowerPoint: Wenn Sie in einer Präsentation unterhalb der letzten Folie klicken, wird eine neue Folie (mit dem Folienmaster der vorherigen Folie) erstellt:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides können Sie die gleiche Aufgabe mit der [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)‑Methode der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse ausführen.


## **Folienmaster in der Folienhierarchie**

Die Verwendung von Folienlayouts zusammen mit dem Folienmaster ermöglicht maximale Flexibilität. Ein Folienlayout erlaubt das Setzen derselben Stile wie beim Folienmaster (Hintergrund, Schriftarten, Formen usw.). Kombinieren Sie mehrere Folienlayouts auf einem Folienmaster, entsteht ein neuer Stil. Wenn Sie ein Folienlayout auf eine einzelne Folie anwenden, kann dessen Stil den durch den Folienmaster gesetzten Stil überschreiben.

Der Folienmaster hat Vorrang vor allen anderen Elementen: Folienmaster → Folienlayout → Folie:

![todo:image_alt_text](slide-master_2)

Jedes [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide)‑Objekt besitzt die [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--)‑Eigenschaft mit einer Liste von Folienlayouts. Ein [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide)‑Typ hat die [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--)‑Eigenschaft, die auf das angewendete Folienlayout verweist. Die Interaktion zwischen Folie und Folienmaster erfolgt über ein Folienlayout.

{{% alert color="info" title="Hinweis" %}}

* In Aspose.Slides sind alle Folieneinrichtungen (Folienmaster, Folienlayout und die Folie selbst) tatsächlich Folienobjekte, die die [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide)‑Schnittstelle implementieren. 
* Daher können Folienmaster und Folienlayout die gleichen Eigenschaften besitzen. Der Folienmaster wird zuerst auf eine Folie angewendet, anschließend das Folienlayout. Haben beide beispielsweise einen Hintergrundwert, verwendet die Folie den Hintergrund des Folienlayouts.

{{% /alert %}}


## **Inhalte eines Folienmasters**

Um zu verstehen, wie ein Folienmaster geändert werden kann, sollten Sie seine Bestandteile kennen. Dies sind die Kern‑Properties des [MasterSlide](https://reference.aspose.com/slides/java/aspose.slides/masterslide/):

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) – Hintergrund der Folie holen/setzen.  
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) – Textstile des Folienkörpers holen/setzen.  
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) – Alle Formen des Folienmasters (Platzhalter, Bildrahmen usw.) holen/setzen.  
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) – ActiveX‑Steuerelemente holen/setzen.  
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) – Theme‑Manager holen.  
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) – Header‑ und Footer‑Manager holen.

Methoden des Folienmasters:

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) – Alle Folien holen, die vom Folienmaster abhängen.  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) – Ermöglicht das Erstellen eines neuen Folienmasters auf Basis des aktuellen Masters und eines neuen Themes. Der neue Master wird anschließend auf alle abhängigen Folien angewendet.


## **Einen Folienmaster erhalten**

In PowerPoint kann man den Folienmaster über das Menü Ansicht → Folienmaster aufrufen:

![todo:image_alt_text](slide-master_3.jpg)

Mit Aspose.Slides greifen Sie wie folgt auf einen Folienmaster zu: 
```java
Presentation pres = new Presentation();
try {
    // Gibt Zugriff auf die Master-Folie der Präsentation
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


Die [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide)‑Schnittstelle repräsentiert einen Folienmaster. Die [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--)‑Eigenschaft (bezogen auf den [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)‑Typ) enthält eine Liste aller in der Präsentation definierten Folienmaster.


## **Ein Bild zu einem Folienmaster hinzufügen**

Wird ein Bild zu einem Folienmaster hinzugefügt, erscheint es auf allen Folien, die von diesem Master abhängen. 

Beispiel: Platzieren Sie das Firmenlogo und einige Bilder auf dem Folienmaster und wechseln Sie anschließend zurück in den Folienbearbeitungsmodus. Das Bild wird auf jeder Folie sichtbar sein. 

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

Weitere Informationen zum Hinzufügen von Bildern zu einer Folie finden Sie im Artikel [Picture Frame](/slides/de/java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Einen Platzhalter zu einem Folienmaster hinzufügen**

Dies sind die standardmäßigen Platzhalter auf einem Folienmaster: 

* Auf Titelstil des Masters klicken, um zu bearbeiten
* Textstile des Masters bearbeiten
* Zweite Ebene
* Dritte Ebene 

Sie erscheinen ebenfalls auf den Folien, die auf dem Folienmaster basieren. Sie können diese Platzhalter auf dem Folienmaster bearbeiten, und die Änderungen werden automatisch auf die Folien angewendet. 

In PowerPoint können Sie einen Platzhalter über den Pfad Folienmaster → Platzhalter einfügen hinzufügen:

![todo:image_alt_text](slide-master_5.png)

Betrachten wir ein komplexeres Beispiel für Platzhalter mit Aspose.Slides. Eine Folie mit von einem Folienmaster templatierten Platzhaltern:

![todo:image_alt_text](slide-master_6.png)

Wir möchten die Formatierung von Titel und Untertitel auf dem Folienmaster so ändern:

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


Der Titelstil und die Formatierung ändern sich für alle Folien, die auf dem Folienmaster basieren:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Siehe auch" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/java/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/java/text-formatting/)

{{% /alert %}}


## **Den Hintergrund eines Folienmasters ändern**

Ändern Sie die Hintergrundfarbe einer Master‑Folien, erhalten alle normalen Folien der Präsentation die neue Farbe. Dieser Java‑Code demonstriert die Operation:
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

Um einen Folienmaster in eine andere Präsentation zu klonen, rufen Sie die [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)‑Methode der Zielpräsentation auf und übergeben einen Folienmaster. Dieser Java‑Code zeigt, wie ein Folienmaster in eine andere Präsentation geklont wird:
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

Aspose.Slides ermöglicht das Hinzufügen mehrerer Folienmaster und Folienlayouts zu einer beliebigen Präsentation. Damit können Stile, Layouts und Formatierungsoptionen für Präsentationsfolien auf vielfältige Weise festgelegt werden. 

In PowerPoint können Sie neue Folienmaster und Layouts (über das „Folienmaster‑Menü“) wie folgt hinzufügen:

![todo:image_alt_text](slide-master_9.jpg)

Mit Aspose.Slides fügen Sie einen neuen Folienmaster hinzu, indem Sie die [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)‑Methode aufrufen:
```java
// Fügt eine neue Masterfolie hinzu
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **Folienmaster vergleichen**

Ein Master‑Slide implementiert die [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide)‑Schnittstelle, die die [**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-)‑Methode enthält. Damit können Master‑Slides verglichen werden. Die Methode liefert `true`, wenn Master‑Slides in Struktur und statischem Inhalt identisch sind. 

Zwei Master‑Slides gelten als gleich, wenn ihre Formen, Stile, Texte, Animationen und sonstigen Einstellungen übereinstimmen. Dabei werden eindeutige Kennungen (z. B. SlideId) und dynamische Inhalte (z. B. aktuelles Datum in einem Datums‑Platzhalter) nicht berücksichtigt. 


## **Einen Folienmaster als Standardansicht der Präsentation festlegen**

Aspose.Slides ermöglicht es, einen Folienmaster als Standardansicht einer Präsentation festzulegen. Die Standardansicht ist das, was Sie zuerst sehen, wenn Sie eine Präsentation öffnen. 

Der folgende Code zeigt, wie ein Folienmaster in Java als Standardansicht einer Präsentation festgelegt wird:
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

Aspose.Slides stellt die [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-)‑Methode (aus der [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)‑Klasse) bereit, um nicht mehr benötigte Master‑Slides zu löschen. Dieser Java‑Code zeigt, wie ein Master‑Slide aus einer PowerPoint‑Präsentation entfernt wird:
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

Ein Folienmaster ist eine Folienvorlage, die Layout, Stile, Designs, Schriftarten, Hintergrund und weitere Eigenschaften für Folien in einer Präsentation definiert. Er ermöglicht das gleichzeitige Festlegen und Ändern des Aussehens aller Präsentationsfolien.  

**Wie wird ein Folienmaster in einer Präsentation angewendet?**

Jede Präsentation enthält standardmäßig mindestens einen Folienmaster. Wird eine neue Folie eingefügt, wird ihr automatisch ein Folienmaster zugewiesen, in der Regel der Master der vorherigen Folie. Eine Präsentation kann mehrere Folienmaster enthalten, um verschiedene Teile individuell zu stylen.  

**Welche Elemente können in einem Folienmaster angepasst werden?**

Ein Folienmaster besteht aus mehreren Kern‑Properties, die angepasst werden können:

- **Background** : Hintergrund der Folie festlegen.  
- **BodyStyle** : Textstile für den Folienkörper definieren.  
- **Shapes** : Alle Formen des Folienmasters verwalten, einschließlich Platzhaltern und Bildrahmen.  
- **Controls** : ActiveX‑Steuerelemente handhaben.  
- **ThemeManager** : Zugriff auf den Theme‑Manager.  
- **HeaderFooterManager** : Header‑ und Footer‑Verwaltung.  

**Wie füge ich ein Bild zu einem Folienmaster hinzu?**

Ein Bild, das zu einem Folienmaster hinzugefügt wird, erscheint auf allen Folien, die von diesem Master abhängen. Beispiel: Das Firmenlogo auf dem Folienmaster platzieren, sodass es auf jeder Folie sichtbar ist.  

**Wie stehen Folienmaster zu Folienlayouts?**

Folienlayouts arbeiten zusammen mit Folienmastern, um Flexibilität im Foliendesign zu bieten. Der Folienmaster legt globale Stile und Designs fest, während Folienlayouts unterschiedliche Anordnungen des Inhalts ermöglichen. Die Hierarchie lautet:

- **Folienmaster** → Definiert globale Stile.  
- **Folienlayout** → Bietet verschiedene Inhaltsanordnungen.  
- **Folie** → Erbt das Design vom zugeordneten Folienlayout.  

**Kann ich mehrere Folienmaster in einer einzigen Präsentation haben?**

Ja, eine Präsentation kann mehrere Folienmaster enthalten. Dies ermöglicht das individuelle Stylen verschiedener Abschnitte einer Präsentation und bietet Gestaltungsspielraum.  

**Wie greife ich mit Aspose.Slides auf einen Folienmaster zu und ändere ihn?**

In Aspose.Slides wird ein Folienmaster durch die [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/)‑Schnittstelle repräsentiert. Sie können einen Folienmaster über die [getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--)‑Methode des [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Objekts abrufen.