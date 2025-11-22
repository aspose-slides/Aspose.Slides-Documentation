---
title: "Was ist ein Folienmaster in PowerPoint? Definition & Anwendungsleitfaden"
linktitle: "Folienmaster"
type: docs
weight: 80
url: /de/net/slide-master/
keywords: "Folienmaster hinzufügen, PPT Master Folie, Folienmaster PowerPoint, Bild zum Folienmaster, Platzhalter, Mehrere Folienmaster, Folienmaster vergleichen, C#, Csharp, .NET, Aspose.Slides"
description: "Erfahren Sie, was ein Folienmaster in PowerPoint ist und wie er Ihnen hilft, Folienlayouts, Schriftarten, Farben und das Branding zu steuern. Einfache Schritt‑für‑Schritt‑Anleitung mit Beispielen in C# oder .NET."
---

## **Was ist ein Folienmaster in PowerPoint**
Ein **Folienmaster** in PowerPoint ist ein Feature, das das Layout, die Schriftarten und die Stile über mehrere Folien hinweg steuert. Er hilft, Konsistenz und Markenbildung in Präsentationen zu erhalten. Wenn Sie eine Präsentation (oder eine Reihe von Präsentationen) mit demselben Stil und derselben Vorlage für Ihr Unternehmen erstellen möchten, können Sie einen Folienmaster verwenden. 

Ein Folienmaster ist nützlich, weil er es Ihnen ermöglicht, das Aussehen aller Präsentationsfolien gleichzeitig festzulegen und zu ändern. Aspose.Slides unterstützt den Folienmaster‑Mechanismus von PowerPoint. 

VBA ermöglicht ebenfalls die Manipulation eines Folienmasters und die Ausführung derselben in PowerPoint unterstützten Vorgänge: Hintergründe ändern, Formen hinzufügen, Layout anpassen usw. Aspose.Slides bietet flexible Mechanismen, um Folienmaster zu verwenden und Grundaufgaben damit auszuführen. 

Dies sind grundlegende Folienmaster‑Operationen:

- Erstellen eines Folienmasters.
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

Möglicherweise möchten Sie den Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) prüfen, weil er eine Live‑Implementierung einiger der hier beschriebenen Kernprozesse darstellt.

{{% /alert %}} 


## **Wie wird ein Folienmaster angewendet**
Bevor Sie mit einem Folienmaster arbeiten, sollten Sie verstehen, wie er in Präsentationen verwendet und auf Folien angewendet wird. 

* Jede Präsentation enthält standardmäßig mindestens einen Folienmaster. 
* Eine Präsentation kann mehrere Folienmaster enthalten. Sie können mehrere Folienmaster hinzufügen und sie verwenden, um verschiedene Teile einer Präsentation unterschiedlich zu gestalten. 

In **Aspose.Slides** wird ein Folienmaster durch den Typ [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) repräsentiert. 

Das Aspose.Slides‑[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Objekt enthält die [**Masters**](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters)‑Liste vom Typ [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), die alle in einer Präsentation definierten Folienmaster auflistet. 

Neben CRUD‑Operationen enthält die [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)‑Schnittstelle nützliche Methoden: [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) und [**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone). Diese Methoden stammen von der grundlegenden Folienklon‑Funktion, erlauben aber bei Folienmastern komplizierte Setups. 

Wird einer Präsentation eine neue Folie hinzugefügt, wird automatischer ein Folienmaster darauf angewendet. Standardmäßig wird der Folienmaster der vorherigen Folie verwendet. 

**Hinweis**: Präsentationsfolien werden in der [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)‑Liste gespeichert, und jede neue Folie wird standardmäßig am Ende der Sammlung eingefügt. Enthält eine Präsentation nur einen Folienmaster, wird dieser für alle neuen Folien verwendet. Deshalb muss der Folienmaster nicht für jede neu erstellte Folie explizit definiert werden.

Das Prinzip ist sowohl für PowerPoint als auch für Aspose.Slides identisch. In PowerPoint können Sie beispielsweise eine neue Folie erzeugen, indem Sie in der unteren Zeile unter der letzten Folie klicken; es wird dann eine neue Folie (mit dem Folienmaster der letzten Folie) erstellt:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides können Sie dieselbe Aufgabe mit der [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone)‑Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse ausführen.


## **Folienmaster in der Folienhierarchie**
Die Verwendung von Folienlayouts zusammen mit dem Folienmaster bietet maximale Flexibilität. Ein Folienlayout ermöglicht es, dieselben Stile wie der Folienmaster (Hintergrund, Schriftarten, Formen usw.) zu setzen. Kombiniert man mehrere Folienlayouts auf einem Folienmaster, entsteht ein neuer Stil. Wird ein Folienlayout auf eine einzelne Folie angewendet, kann dessen Stil vom Folienmaster‑Stil abweichen.

Der Folienmaster hat Vorrang vor allen anderen Ebenen: Folienmaster → Folienlayout → Folie:

![todo:image_alt_text](slide-master_2)



Jedes [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide)‑Objekt besitzt die [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides)‑Eigenschaft, die eine Liste von Folienlayouts enthält. Ein [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide)‑Typ hat die [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide)‑Eigenschaft, die auf das angewendete Folienlayout verweist. Die Interaktion zwischen einer Folie und dem Folienmaster erfolgt über ein Folienlayout.

{{% alert color="info" title="Note" %}}

* In Aspose.Slides sind alle Folieneinstellungen (Folienmaster, Folienlayout und die Folie selbst) tatsächlich Folienobjekte, die das [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide)‑Interface implementieren. 
* Daher können Folienmaster und Folienlayout die gleichen Eigenschaften besitzen und Sie müssen wissen, wie deren Werte auf ein [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)‑Objekt angewendet werden. Der Folienmaster wird zuerst auf die Folie angewendet, danach das Folienlayout. Beispiel: Haben sowohl Folienmaster als auch Folienlayout einen Hintergrundwert, so wird abschließend der Hintergrund des Folienlayouts verwendet.

{{% /alert %}}


## **Was ein Folienmaster enthält**
Um zu verstehen, wie ein Folienmaster geändert werden kann, müssen Sie seine Bestandteile kennen. Dies sind die Kern‑Eigenschaften von [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/):

- [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) - Folienhintergrund abrufen/setzen. 
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) - Textstile des Folienkörpers abrufen/setzen. 
- [Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) - Alle Formen des Folienmasters (Platzhalter, Bilderrahmen usw.) abrufen/setzen. 
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) - ActiveX‑Steuerelemente abrufen/setzen. 
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) - Theme‑Manager abrufen. 
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) - Header‑ und Footer‑Manager abrufen. 

Folienmaster‑Methoden:

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) - Alle Folien ermitteln, die vom Folienmaster abhängen. 
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) - Ermöglicht das Erstellen eines neuen Folienmasters basierend auf dem aktuellen Folienmaster und einem neuen Theme. Der neue Folienmaster wird anschließend auf alle abhängigen Folien angewendet. 


## **Folienmaster abrufen**
In PowerPoint kann der Folienmaster über das Menü Ansicht → Folienmaster aufgerufen werden:

![todo:image_alt_text](slide-master_3.jpg)



Mit Aspose.Slides können Sie einen Folienmaster wie folgt abrufen:
```c#
IMasterSlide master = pres.Masters[0];
```


Das [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide)‑Interface repräsentiert einen Folienmaster. Die [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/)‑Eigenschaft (bezogen auf den Typ [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)) enthält eine Liste aller in der Präsentation definierten Folienmaster. 


## **Bild zum Folienmaster hinzufügen**
Wird ein Bild zu einem Folienmaster hinzugefügt, erscheint dieses Bild auf allen Folien, die von diesem Master abhängen. 

Beispielsweise können Sie das Firmenlogo und einige Bilder auf dem Folienmaster platzieren und danach in den Folienbearbeitungsmodus zurückkehren. Das Bild wird dann auf jeder Folie sichtbar sein. 

![todo:image_alt_text](slide-master_4.png)

Sie können mit Aspose.Slides Bilder zu einem Folienmaster hinzufügen: 
```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" title="See also" %}} 

Weitere Informationen zum Hinzufügen von Bildern zu einer Folie finden Sie im Artikel [Picture Frame](/slides/de/net/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Platzhalter zum Folienmaster hinzufügen**
Dies sind Standard‑Platzhalter auf einem Folienmaster: 

* Klicken Sie, um den Master‑Titelstil zu bearbeiten

* Master‑Textstile bearbeiten

* Zweite Ebene

* Dritte Ebene 

Sie erscheinen auch auf den Folien, die auf dem Folienmaster basieren. Sie können diese Platzhalter auf einem Folienmaster bearbeiten, und die Änderungen werden automatisch auf die Folien angewendet. 

In PowerPoint können Sie über den Pfad Folienmaster → Platzhalter einfügen einen Platzhalter hinzufügen:

![todo:image_alt_text](slide-master_5.png)

Betrachten wir ein komplexeres Beispiel für Platzhalter mit Aspose.Slides. Angenommen, eine Folie enthält Platzhalter, die aus dem Folienmaster stammen:

![todo:image_alt_text](slide-master_6.png)

Wir wollen Titel‑ und Untertitel‑Formatierung auf dem Folienmaster wie folgt ändern:

![todo:image_alt_text](slide-master_7.png)

Zuerst holen wir den Inhalt des Titel‑Platzhalters aus dem Folienmaster‑Objekt und verwenden dann das Feld `PlaceHolder.FillFormat`:
```c#
public static void Main()
{
    using (var pres = new Presentation())
    {
        IMasterSlide master = pres.Masters[0];
        IAutoShape placeHolder = FindPlaceholder(master, PlaceholderType.Title);
        placeHolder.FillFormat.FillType = FillType.Gradient;
        placeHolder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
        placeHolder.FillFormat.GradientFormat.GradientStops.Add(0, Color.FromArgb(255, 0, 0));
        placeHolder.FillFormat.GradientFormat.GradientStops.Add(255, Color.FromArgb(128, 0, 128));
        
        pres.Save("pres.pptx", SaveFormat.Pptx);
    }
}

static IAutoShape FindPlaceholder(IMasterSlide master, PlaceholderType type)
{
    foreach (IShape shape in master.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            if (autoShape.Placeholder.Type == type)
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

{{% alert color="primary" title="See also" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/net/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/net/text-formatting/)

{{% /alert %}}


## **Hintergrund im Folienmaster ändern**
Wenn Sie die Hintergrundfarbe einer Master‑Folie ändern, erhalten alle normalen Folien in der Präsentation die neue Farbe. Dieser C#‑Code demonstriert den Vorgang:
```c#
using (var pres = new Presentation())
{
    IMasterSlide master = pres.Masters[0];
    master.Background.Type = BackgroundType.OwnBackground;
    master.Background.FillFormat.FillType = FillType.Solid;
    master.Background.FillFormat.SolidFillColor.Color = Color.Green;
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" title="See also" %}} 
- [Presentation Background](https://docs.aspose.com/slides/net/presentation-background/)

- [Presentation Theme](https://docs.aspose.com/slides/net/presentation-theme/)

{{% /alert %}}

## **Folienmaster in andere Präsentation klonen**
Um einen Folienmaster in eine andere Präsentation zu klonen, rufen Sie die [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2)‑Methode der Zielpräsentation auf und übergeben ihr den zu klonenden Folienmaster. Dieser C#‑Code zeigt, wie ein Folienmaster in eine andere Präsentation geklont wird:
```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```



## **Mehrere Folienmaster zur Präsentation hinzufügen**
Aspose.Slides ermöglicht das Hinzufügen mehrerer Folienmaster und Folienlayouts zu einer beliebigen Präsentation. Damit können Sie Stile, Layouts und Formatierungsoptionen für Präsentationsfolien auf verschiedene Weise festlegen. 

In PowerPoint können Sie neue Folienmaster und Layouts (aus dem „Folienmaster‑Menü“) wie folgt hinzufügen:

![todo:image_alt_text](slide-master_9.jpg)

Mit Aspose.Slides können Sie einen neuen Folienmaster hinzufügen, indem Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/)‑Methode aufrufen:
```c#
pres.Masters.AddClone(pres.Masters[0]);
```



## **Folienmaster vergleichen**
Ein Master‑Slide implementiert das [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide)‑Interface, das die [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals)‑Methode enthält, die zum Vergleich von Folien verwendet werden kann. Sie gibt `true` zurück, wenn Master‑Slides in Struktur und statischem Inhalt identisch sind. 

Zwei Master‑Slides sind gleich, wenn ihre Formen, Stile, Texte, Animationen und weitere Einstellungen gleich sind. Der Vergleich berücksichtigt nicht eindeutige Kennungen (z. B. SlideId) und dynamische Inhalte (z. B. aktuelles Datum in einem Datums‑Platzhalter). 


## **Folienmaster als Standardansicht der Präsentation festlegen**
Aspose.Slides ermöglicht das Festlegen eines Folienmasters als Standardansicht einer Präsentation. Die Standardansicht ist das, was Sie zuerst sehen, wenn Sie eine Präsentation öffnen. 

Dieser Code zeigt, wie Sie einen Folienmaster als Standardansicht einer Präsentation in C# festlegen:
```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```


## **Unbenutzten Folienmaster entfernen**
Aspose.Slides stellt die Methode [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (aus der [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)‑Klasse) bereit, um nicht mehr benötigte Master‑Slides zu löschen. Dieser C#‑Code zeigt, wie ein Master‑Slide aus einer PowerPoint‑Präsentation entfernt wird:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Was ist ein Folienmaster in PowerPoint?**

Ein Folienmaster ist eine Folienvorlage, die Layout, Stile, Themen, Schriftarten, Hintergrund und weitere Eigenschaften für Folien einer Präsentation definiert. Er ermöglicht das gleichzeitige Festlegen und Ändern des Aussehens aller Präsentationsfolien.  

**Wie wird ein Folienmaster in einer Präsentation angewendet?**

Jede Präsentation enthält standardmäßig mindestens einen Folienmaster. Beim Hinzufügen einer neuen Folie wird automatisch ein Folienmaster darauf angewendet, meist der Master der vorherigen Folie. Eine Präsentation kann mehrere Folienmaster enthalten, um verschiedene Teile individuell zu gestalten.  

**Welche Elemente können in einem Folienmaster angepasst werden?**

Ein Folienmaster besteht aus mehreren Kern‑Eigenschaften, die angepasst werden können:

- **Background**: Folienhintergrund festlegen. 
- **BodyStyle**: Textstile für den Folienkörper definieren. 
- **Shapes**: Alle Formen auf dem Folienmaster verwalten, einschließlich Platzhaltern und Bildrahmen. 
- **Controls**: ActiveX‑Steuerelemente verwalten. 
- **ThemeManager**: Zugriff auf den Theme‑Manager. 
- **HeaderFooterManager**: Header und Footer verwalten.  

**Wie kann ich ein Bild zu einem Folienmaster hinzufügen?**

Das Hinzufügen eines Bildes zu einem Folienmaster sorgt dafür, dass es auf allen Folien erscheint, die von diesem Master abhängen. Beispielsweise wird ein Firmenlogo, das auf dem Folienmaster platziert wird, auf jeder Folie der Präsentation angezeigt.  

**Wie stehen Folienmaster zu Folienlayouts?**

Folienlayouts arbeiten zusammen mit Folienmastern, um Flexibilität im Foliendesign zu bieten. Während ein Folienmaster globale Stile und Themen definiert, ermöglichen Folienlayouts Variationen in der Anordnung des Inhalts. Die Hierarchie lautet:

- **Folienmaster** → Definiert globale Stile. 
- **Folienlayout** → Bietet unterschiedliche Inhaltsanordnungen. 
- **Folie** → Erbt das Design von ihrem Folienlayout.  

**Kann ich mehrere Folienmaster in einer einzigen Präsentation haben?**

Ja, eine Präsentation kann mehrere Folienmaster enthalten. Das ermöglicht das individuelle Gestalten verschiedener Abschnitte einer Präsentation und bietet Design‑Flexibilität.  

**Wie greife ich in Aspose.Slides auf einen Folienmaster zu und modifiziere ihn?**

In Aspose.Slides wird ein Folienmaster durch das `IMasterSlide`‑Interface repräsentiert. Sie können einen Folienmaster über die `Masters`‑Eigenschaft des `Presentation`‑Objekts abrufen.