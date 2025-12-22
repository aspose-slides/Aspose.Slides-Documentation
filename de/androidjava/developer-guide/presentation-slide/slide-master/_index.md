---
title: Verwalten von Folienmastern in Präsentationen auf Android
linktitle: Folienmaster
type: docs
weight: 70
url: /de/androidjava/slide-master/
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
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie Folienmaster in Aspose.Slides für Android: Erstellen, Bearbeiten und Anwenden von Layouts, Designs und Platzhaltern für PPT, PPTX und ODP mit knappen Java-Beispielen."
---

## **Was ist ein Folienmaster in PowerPoint**

Ein **Slide Master** ist eine Folienvorlage, die Layout, Stile, Design, Schriften, Hintergrund und weitere Eigenschaften für Folien einer Präsentation definiert. Wenn Sie eine Präsentation (oder eine Reihe von Präsentationen) mit demselben Stil und derselben Vorlage für Ihr Unternehmen erstellen möchten, können Sie einen Folienmaster verwenden.

Ein Folienmaster ist nützlich, weil er es ermöglicht, das Aussehen aller Folien einer Präsentation gleichzeitig festzulegen und zu ändern. Aspose.Slides unterstützt den Folienmaster‑Mechanismus von PowerPoint.

VBA ermöglicht ebenfalls die Manipulation eines Folienmasters und die Ausführung derselben Operationen, die in PowerPoint unterstützt werden: Hintergründe ändern, Formen hinzufügen, Layout anpassen usw. Aspose.Slides bietet flexible Mechanismen, um Folienmaster zu verwenden und grundlegende Aufgaben damit auszuführen.

Dies sind grundlegende Folienmaster‑Operationen:

- Erstellen oder **Slide Master**.
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
Vielleicht möchten Sie den Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) ausprobieren, da er eine Live‑Implementierung einiger hier beschriebener Kernprozesse darstellt. 
{{% /alert %}} 

## **Wie wird ein Folienmaster angewendet**

Bevor Sie mit einem Folienmaster arbeiten, sollten Sie verstehen, wie er in Präsentationen verwendet und auf Folien angewendet wird. 

* Jede Präsentation enthält standardmäßig mindestens einen Folienmaster. 
* Eine Präsentation kann mehrere Folienmaster enthalten. Sie können mehrere Folienmaster hinzufügen und sie verwenden, um verschiedene Teile einer Präsentation unterschiedlich zu gestalten. 

In **Aspose.Slides** wird ein Folienmaster durch den Typ [**IMasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) repräsentiert.

Das Aspose.Slides‑Objekt [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) enthält die Liste [**getMasters**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) des Typs [**IMasterSlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), die alle in einer Präsentation definierten Folienmaster auflistet.

Neben CRUD‑Operationen enthält die Schnittstelle [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) nützliche Methoden: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) und [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). Diese Methoden stammen aus der Grundfunktion zum Klonen von Folien. Beim Arbeiten mit Folienmastern ermöglichen sie jedoch komplizierte Setups.

Wenn einer Präsentation eine neue Folie hinzugefügt wird, wird automatisch ein Folienmaster darauf angewendet. Standardmäßig wird der Folienmaster der vorherigen Folie übernommen. 

**Hinweis**: Präsentationsfolien werden in der Liste [getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) gespeichert, und jede neue Folie wird standardmäßig am Ende der Sammlung eingefügt. Enthält eine Präsentation nur einen Folienmaster, wird dieser für alle neuen Folien verwendet. Deshalb müssen Sie den Folienmaster nicht für jede neu erstellte Folie explizit festlegen.

Das Prinzip ist für PowerPoint und Aspose.Slides identisch. In PowerPoint können Sie beispielsweise am unteren Rand der letzten Folie klicken, um eine neue Folie (mit dem Folienmaster der vorherigen Folie) zu erzeugen:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides erledigen Sie dieselbe Aufgabe mit der Methode [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).

## **Folienmaster in der Folienhierarchie**

Die Verwendung von Folienlayouts zusammen mit dem Folienmaster bietet maximale Flexibilität. Ein Folienlayout ermöglicht das Festlegen derselben Stile wie beim Folienmaster (Hintergrund, Schriften, Formen usw.). Wenn mehrere Folienlayouts auf einem Folienmaster kombiniert werden, entsteht ein neuer Stil. Wird ein Folienlayout auf eine einzelne Folie angewendet, überschreibt es den vom Folienmaster übernommenen Stil.

Der Folienmaster steht über allen anderen Elementen: Folienmaster → Folienlayout → Folie:

![todo:image_alt_text](slide-master_2)

Jedes [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide)-Objekt besitzt die Eigenschaft [**getLayoutSlides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getLayoutSlides--) mit einer Liste von Folienlayouts. Ein [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide)-Typ hat die Eigenschaft [**getLayoutSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getLayoutSlide--) mit einem Verweis auf das auf die Folie angewendete Folienlayout. Die Interaktion zwischen Folie und Folienmaster erfolgt über ein Folienlayout.

{{% alert color="info" title="Hinweis" %}}
* In Aspose.Slides sind alle Folieneinstellungen (Folienmaster, Folienlayout und die Folie selbst) tatsächlich Folienobjekte, die das Interface [**IBaseSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) implementieren. 
* Daher können Folienmaster und Folienlayout dieselben Eigenschaften besitzen. Der Folienmaster wird zuerst auf die Folie angewendet, danach das Folienlayout. Hat beispielsweise sowohl der Folienmaster als auch das Folienlayout einen Hintergrundwert, übernimmt die Folie den Hintergrund des Folienlayouts. 
{{% /alert %}}

## **Was ein Folienmaster enthält**

Um zu verstehen, wie ein Folienmaster geändert werden kann, müssen Sie seine Bestandteile kennen. Das sind die Kerneigenschaften des [MasterSlide](https://reference.aspose.com/slides/androidjava/aspose.slides/masterslide/):

- [getBackground](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getBackground--) – Liest/Schreibt den Folienhintergrund. 
- [getBodyStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getBodyStyle--) – Liest/Schreibt Textstile des Folienkörpers. 
- [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getShapes--) – Liest/Schreibt alle Formen des Folienmasters (Platzhalter, Bildrahmen usw.). 
- [getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getControls--) – Liest/Schreibt ActiveX‑Steuerelemente. 
- [getThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterThemeable#getThemeManager--) – Liest den Theme‑Manager. 
- [getHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) – Liest den Header‑ und Footer‑Manager. 

Methoden des Folienmasters:

- [getDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getDependingSlides--) – liefert alle Folien, die vom Folienmaster abhängen. 
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) – ermöglicht das Erstellen eines neuen Folienmasters auf Basis des aktuellen Masters und eines neuen Themes; der neue Master wird anschließend auf alle abhängigen Folien angewendet. 

## **Einen Folienmaster abrufen**

In PowerPoint kann der Folienmaster über das Menü **Ansicht → Folienmaster** aufgerufen werden:

![todo:image_alt_text](slide-master_3.jpg)

Mit Aspose.Slides greifen Sie wie folgt auf einen Folienmaster zu: 
```java
Presentation pres = new Presentation();
try {
    // Gibt Zugriff auf den Master-Slide der Präsentation
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


Das Interface [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) repräsentiert einen Folienmaster. Die Eigenschaft [Masters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getMasters--) (bezogen auf den Typ [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection)) enthält eine Liste aller in der Präsentation definierten Folienmaster. 

## **Ein Bild zu einem Folienmaster hinzufügen**

Wenn Sie ein Bild zu einem Folienmaster hinzufügen, wird dieses Bild auf allen Folien angezeigt, die von diesem Master abhängen. 

Beispielsweise können Sie das Firmenlogo und einige weitere Bilder auf dem Folienmaster platzieren und anschließend in den Folien‑Bearbeitungsmodus zurückwechseln – das Bild erscheint dann auf jeder Folie. 

![todo:image_alt_text](slide-master_4.png)

Bilder zu einem Folienmaster fügen Sie mit Aspose.Slides hinzu:
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
Weitere Informationen zum Hinzufügen von Bildern zu einer Folie finden Sie im Artikel [Picture Frame](/slides/de/androidjava/picture-frame/#create-picture-frame). 
{{% /alert %}}

## **Einen Platzhalter zu einem Folienmaster hinzufügen**

Diese Textfelder sind Standard‑Platzhalter auf einem Folienmaster: 

* Klick zum Bearbeiten des Master‑Titelstils  
* Master‑Textstile bearbeiten  
* Zweite Ebene  
* Dritte Ebene  

Sie erscheinen ebenfalls auf den von dem Folienmaster abgeleiteten Folien. Sie können diese Platzhalter auf dem Folienmaster bearbeiten und die Änderungen werden automatisch auf die Folien übertragen. 

In PowerPoint können Sie über **Folienmaster → Platzhalter einfügen** einen Platzhalter hinzufügen:

![todo:image_alt_text](slide-master_5.png)

Ein etwas komplexeres Beispiel für Platzhalter mit Aspose.Slides sehen Sie unten. Eine Folie enthält Platzhalter, die aus dem Folienmaster stammen:

![todo:image_alt_text](slide-master_6.png)

Wir möchten die Titel‑ und Untertitel‑Formatierung auf dem Folienmaster wie folgt ändern:

![todo:image_alt_text](slide-master_7.png)

Zunächst holen wir den Inhalt des Titel‑Platzhalters vom Folienmaster‑Objekt und nutzen anschließend das Feld `PlaceHolder.FillFormat`:
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


Der Titelstil und die Formatierung ändern sich für alle Folien, die den Folienmaster verwenden:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Siehe auch" %}} 
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/androidjava/manage-placeholder/) 
* [Text Formatting](https://docs.aspose.com/slides/androidjava/text-formatting/) 
{{% /alert %}}

## **Den Hintergrund eines Folienmasters ändern**

Wenn Sie die Hintergrundfarbe eines Master‑Slides ändern, erhalten alle normalen Folien der Präsentation die neue Farbe. Dieser Java‑Code demonstriert die Vorgehensweise:
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
- [Presentation Background](https://docs.aspose.com/slides/androidjava/presentation-background/) 
- [Presentation Theme](https://docs.aspose.com/slides/androidjava/presentation-theme/) 
{{% /alert %}}

## **Einen Folienmaster in eine andere Präsentation klonen**

Um einen Folienmaster in eine andere Präsentation zu klonen, rufen Sie die Methode [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) der Zielpräsentation auf und übergeben den zu klonenden Folienmaster. Dieser Java‑Code zeigt, wie ein Folienmaster in eine andere Präsentation geklont wird:
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

In PowerPoint können Sie neue Folienmaster und Layouts (über das **Folienmaster‑Menü**) folgendermaßen hinzufügen:

![todo:image_alt_text](slide-master_9.jpg)

Mit Aspose.Slides fügen Sie einen neuen Folienmaster hinzu, indem Sie die Methode [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) aufrufen:
```java
// Fügt eine neue Masterfolie hinzu
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **Folienmaster vergleichen**

Ein Master‑Slide implementiert das Interface [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) mit der Methode [**equals**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-), die zum Vergleich von Folien verwendet werden kann. Sie liefert `true`, wenn Master‑Slides in Struktur und statischem Inhalt identisch sind.

Zwei Master‑Slides sind gleich, wenn ihre Formen, Stile, Texte, Animationen und weitere Einstellungen übereinstimmen. Der Vergleich berücksichtigt nicht die eindeutigen Kennungen (z. B. SlideId) und dynamische Inhalte (z. B. das aktuelle Datum in einem Datums‑Platzhalter). 

## **Einen Folienmaster als Standardansicht der Präsentation festlegen**

Aspose.Slides erlaubt das Festlegen eines Folienmasters als Standardansicht einer Präsentation. Die Standardansicht ist das, was Sie zuerst sehen, wenn Sie eine Präsentation öffnen. 

Der folgende Code zeigt, wie ein Folienmaster in Java als Standardansicht einer Präsentation gesetzt wird:
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

Aspose.Slides stellt die Methode [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (aus der Klasse [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)) bereit, um nicht mehr benötigte Master‑Slides zu löschen. Dieser Java‑Code zeigt, wie ein Master‑Slide aus einer PowerPoint‑Präsentation entfernt wird:
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
Ein Folienmaster ist eine Folienvorlage, die Layout, Stile, Design, Schriften, Hintergrund und weitere Eigenschaften für Folien einer Präsentation definiert. Er ermöglicht das gleichzeitige Festlegen und Ändern des Aussehens aller Präsentationsfolien.  

**Wie wird ein Folienmaster in einer Präsentation angewendet?**  
Jede Präsentation enthält standardmäßig mindestens einen Folienmaster. Beim Hinzufügen einer neuen Folie wird automatisch ein Folienmaster darauf angewendet, in der Regel der Master der vorherigen Folie. Eine Präsentation kann mehrere Folienmaster enthalten, um verschiedene Teile individuell zu gestalten.  

**Welche Elemente können in einem Folienmaster angepasst werden?**  
Ein Folienmaster besteht aus mehreren Kerneigenschaften, die angepasst werden können:

- **Background** : Hintergrund der Folie festlegen.  
- **BodyStyle** : Textstile des Folienkörpers definieren.  
- **Shapes** : Alle Formen auf dem Folienmaster verwalten, einschließlich Platzhaltern und Bildrahmen.  
- **Controls** : ActiveX‑Steuerelemente handhaben.  
- **ThemeManager** : Zugriff auf den Theme‑Manager.  
- **HeaderFooterManager** : Kopf- und Fußzeilen verwalten.  

**Wie füge ich ein Bild zu einem Folienmaster hinzu?**  
Durch das Hinzufügen eines Bildes zu einem Folienmaster erscheint es auf allen Folien, die von diesem Master abhängen. Beispielsweise wird ein Firmenlogo, das auf dem Folienmaster platziert wird, auf jeder Folie der Präsentation angezeigt.  

**Wie stehen Folienmaster und Folienlayouts zueinander?**  
Folienlayouts arbeiten zusammen mit Folienmastern, um Flexibilität im Foliendesign zu bieten. Der Folienmaster definiert globale Stile und Designs, während Folienlayouts Variationen in der Anordnung des Inhalts ermöglichen. Die Hierarchie lautet:

- **Folienmaster** → Definiert globale Stile.  
- **Folienlayout** → Bietet unterschiedliche Inhaltsanordnungen.  
- **Folie** → Erbt das Design vom zugewiesenen Folienlayout.  

**Kann ich mehrere Folienmaster in einer einzigen Präsentation haben?**  
Ja, eine Präsentation kann mehrere Folienmaster enthalten. Dies ermöglicht das unterschiedlich gestylte Gestalten verschiedener Abschnitte einer Präsentation und bietet Design‑Flexibilität.  

**Wie greife ich in Aspose.Slides auf einen Folienmaster zu und ändere ihn?**  
In Aspose.Slides wird ein Folienmaster durch das Interface [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) repräsentiert. Sie können einen Folienmaster über die Methode [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) des [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Objekts abrufen.