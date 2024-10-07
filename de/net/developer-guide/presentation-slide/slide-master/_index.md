---
title: Folienmaster
type: docs
weight: 80
url: /net/slide-master/
keywords: "Folienmaster hinzufügen, PPT-Folienmaster, Folienmaster PowerPoint, Bild zum Folienmaster, Platzhalter, mehrere Folienmaster, Folienmaster vergleichen, C#, Csharp, .NET, Aspose.Slides"
description: "Fügen Sie einen Folienmaster in einer PowerPoint-Präsentation in C# oder .NET hinzu oder bearbeiten Sie ihn."
---


## **Was ist ein Folienmaster in PowerPoint**
Ein **Folienmaster** ist eine Folienvorlage, die das Layout, die Stile, das Thema, die Schriftarten, den Hintergrund und andere Eigenschaften für Folien in einer Präsentation definiert. Wenn Sie eine Präsentation (oder eine Reihe von Präsentationen) mit dem gleichen Stil und der gleichen Vorlage für Ihr Unternehmen erstellen möchten, können Sie einen Folienmaster verwenden. 

Ein Folienmaster ist nützlich, weil er es Ihnen ermöglicht, das Aussehen aller Präsentationsfolien auf einmal festzulegen und zu ändern. Aspose.Slides unterstützt den Folienmaster-Mechanismus von PowerPoint. 

VBA ermöglicht es Ihnen auch, einen Folienmaster zu manipulieren und die gleichen Operationen auszuführen, die in PowerPoint unterstützt werden: Hintergründe ändern, Formen hinzufügen, das Layout anpassen usw. Aspose.Slides bietet flexible Mechanismen, die es Ihnen ermöglichen, Folienmaster zu verwenden und grundlegende Aufgaben mit ihnen auszuführen. 

Dies sind grundlegende Folienmaster-Operationen:

- Erstellen oder Bearbeiten des Folienmasters.
- Folienmaster auf Präsentationsfolien anwenden.
- Hintergrund des Folienmasters ändern.
- Ein Bild, Platzhalter, Smart Art usw. zum Folienmaster hinzufügen.

Dies sind fortgeschrittenere Operationen, die den Folienmaster betreffen: 

- Folienmaster vergleichen.
- Folienmaster zusammenführen.
- Mehrere Folienmaster anwenden.
- Folie mit Folienmaster in eine andere Präsentation kopieren.
- Duplizierte Folienmaster in Präsentationen finden.
- Folienmaster als Standardansicht der Präsentation festlegen.

{{% alert color="primary" %}} 

Sie sollten sich den Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) ansehen, da dies eine Live-Implementierung einiger der hier beschriebenen Kernprozesse ist.

{{% /alert %}} 


## **Wie wird der Folienmaster angewendet**
Bevor Sie mit einem Folienmaster arbeiten, sollten Sie verstehen, wie er in Präsentationen verwendet und auf Folien angewendet wird. 

* Jede Präsentation hat standardmäßig mindestens einen Folienmaster. 
* Eine Präsentation kann mehrere Folienmaster enthalten. Sie können mehrere Folienmaster hinzufügen und sie verwenden, um verschiedene Teile einer Präsentation auf unterschiedliche Weise zu gestalten. 

In **Aspose.Slides** wird ein Folienmaster vom Typ [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) dargestellt. 

Das [Präsentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekt von Aspose.Slides enthält die [**Masters** ](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters)-Liste vom Typ [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), die eine Liste aller Masterfolien enthält, die in einer Präsentation definiert sind. 

Neben CRUD-Operationen enthält die [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) -Schnittstelle diese nützlichen Methoden: [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) und [**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone). Diese Methoden sind von der grundlegenden Folienklonfunktion abgeleitet. Aber beim Arbeiten mit Folienmastern ermöglichen Ihnen diese Methoden, komplizierte Setups zu implementieren. 

Wenn einer Präsentation eine neue Folie hinzugefügt wird, wird automatisch ein Folienmaster darauf angewendet. Standardmäßig wird der Folienmaster der vorherigen Folie ausgewählt. 

**Hinweis**: Präsentationsfolien werden in der [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)-Liste gespeichert, und jede neue Folie wird standardmäßig am Ende der Sammlung hinzugefügt. Wenn eine Präsentation nur einen Folienmaster enthält, wird dieser Folienmaster für alle neuen Folien ausgewählt. Aus diesem Grund müssen Sie den Folienmaster nicht für jede neue Folie definieren, die Sie erstellen.

Das Prinzip ist dasselbe für PowerPoint und Aspose.Slides. Zum Beispiel, in PowerPoint, wenn Sie eine neue Präsentation hinzufügen, können Sie einfach auf die untere Linie unter der letzten Folie klicken und dann wird eine neue Folie (mit dem Folienmaster der letzten Präsentation) erstellt:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides können Sie die entsprechende Aufgabe mit der [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone) -Methode unter der [Präsentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse ausführen.


## **Folienmaster in der Folienhierarchie**
Die Verwendung von Folienlayouts mit dem Folienmaster ermöglicht maximale Flexibilität. Ein Folienlayout ermöglicht es Ihnen, alle gleichen Stile wie der Folienmaster festzulegen (Hintergrund, Schriftarten, Formen usw.). Wenn jedoch mehrere Folienlayouts auf einem Folienmaster kombiniert werden, wird ein neuer Stil erstellt. Wenn Sie ein Folienlayout auf eine einzelne Folie anwenden, können Sie dessen Stil von dem, der vom Folienmaster angewendet wurde, ändern.

Der Folienmaster hat Vorrang vor allen Setup-Elementen: Folienmaster -> Folienlayout -> Folie:

![todo:image_alt_text](slide-master_2)

Jedes [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) -Objekt hat eine [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides)-Eigenschaft mit einer Liste von Folienlayouts. Ein [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) -Typ hat eine [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide) -Eigenschaft mit einem Link zu einem Folienlayout, das auf die Folie angewendet wurde. Die Interaktion zwischen einer Folie und dem Folienmaster erfolgt über ein Folienlayout.

{{% alert color="info" title="Hinweis" %}}

* 
   In Aspose.Slides sind alle Folien-Setups (Folienmaster, Folienlayout und die Folie selbst) tatsächlich Folienobjekte, die das [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) -Interface implementieren.
* Daher können Folienmaster und Folienlayout dieselben Eigenschaften implementieren, und Sie müssen wissen, wie deren Werte auf ein [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/) -Objekt angewendet werden. Der Folienmaster wird zuerst auf eine Folie angewendet und dann das Folienlayout. Zum Beispiel, wenn der Folienmaster und das Folienlayout beide einen Hintergrundwert haben, wird die Folie mit dem Hintergrund des Folienlayouts enden.

{{% /alert %}}


## **Was ein Folienmaster umfasst**
Um zu verstehen, wie ein Folienmaster geändert werden kann, müssen Sie seine Bestandteile kennen. Dies sind die Kern Eigenschaften des [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/). 

- [Hintergrund](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) - Hintergrund der Folie abrufen/festlegen.
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) - Textstile des Folieninhalts abrufen/festlegen.
- [Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) - Alle Formen des Folienmasters (Platzhalter, Bildrahmen usw.) abrufen/festlegen.
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) - ActiveX-Steuerelemente abrufen/festlegen.
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) - Themenmanager abrufen.
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) - Header- und Footer-Manager abrufen.

Methoden des Folienmasters:

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) - Alle Folien abrufen, die vom Folienmaster abhängen.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) - Ermöglicht das Erstellen eines neuen Folienmasters auf der Grundlage des aktuellen Folienmasters und eines neuen Themas. Der neue Folienmaster wird dann auf alle abhängigen Folien angewendet.


## **Folienmaster abrufen**
In PowerPoint kann der Folienmaster über das Menü Ansicht -> Folienmaster aufgerufen werden:

![todo:image_alt_text](slide-master_3.jpg)

Mit Aspose.Slides können Sie auf einen Folienmaster wie folgt zugreifen:

```c#
IMasterSlide master = pres.Masters[0];
```

Das [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) -Interface repräsentiert einen Folienmaster. Die [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) -Eigenschaft (die mit dem [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) -Typ verbunden ist) enthält eine Liste aller Folienmaster, die in der Präsentation definiert sind. 


## **Bild zum Folienmaster hinzufügen**
Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf allen Folien, die von diesem Folienmaster abhängen. 

Sie können beispielsweise das Logo Ihres Unternehmens und einige Bilder auf dem Folienmaster platzieren und anschließend wieder in den Folienbearbeitungsmodus wechseln. Sie sollten das Bild auf jeder Folie sehen. 

![todo:image_alt_text](slide-master_4.png)

Sie können Bilder zu einem Folienmaster mit Aspose.Slides hinzufügen: 

```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" title="Siehe auch" %}} 

Für weitere Informationen zum Hinzufügen von Bildern zu einer Folie siehe den Artikel [Bildrahmen](/slides/net/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Platzhalter zum Folienmaster hinzufügen**
Diese Textfelder sind Standardplatzhalter auf einem Folienmaster: 

* Klicken Sie hier, um den Stil des Mastertitels zu bearbeiten

* Bearbeiten Sie die Textstile des Masters

* Zweite Ebene

* Dritte Ebene 

  Sie erscheinen auch auf den Folien, die auf dem Folienmaster basieren. Sie können diese Platzhalter auf einem Folienmaster bearbeiten und die Änderungen werden automatisch auf die Folien angewendet. 

In PowerPoint können Sie einen Platzhalter über den Pfad Folienmaster -> Platzhalter einfügen hinzufügen:



![todo:image_alt_text](slide-master_5.png)



Lassen Sie uns ein komplizierteres Beispiel für Platzhalter mit Aspose.Slides betrachten. Betrachten Sie eine Folie mit Platzhaltern, die vom Folienmaster vorgegeben sind:



![todo:image_alt_text](slide-master_6.png)



Wir möchten die Formatierung von Titel und Untertitel im Folienmaster wie folgt ändern:

![todo:image_alt_text](slide-master_7.png)



Zuerst rufen wir den Inhalt des Titelplatzhalters vom Folienmaster-Objekt ab und verwenden dann das `PlaceHolder.FillFormat`-Feld: 

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

{{% alert color="primary" title="Siehe auch" %}} 

* [Platzhaltertext festlegen](https://docs.aspose.com/slides/net/manage-placeholder/)
* [Textformatierung](https://docs.aspose.com/slides/net/text-formatting/)

{{% /alert %}}


## **Hintergrund im Folienmaster ändern**
Wenn Sie die Hintergrundfarbe eines Folienmasters ändern, erhalten alle normalen Folien in der Präsentation die neue Farbe. Dieser C#-Code demonstriert die Operation:

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

{{% alert color="primary" title="Siehe auch" %}} 
- [Hintergrund der Präsentation](https://docs.aspose.com/slides/net/presentation-background/)

- [Präsentationsthema](https://docs.aspose.com/slides/net/presentation-theme/)

  {{% /alert %}}

## **Folienmaster in eine andere Präsentation klonen**
Um einen Folienmaster in eine andere Präsentation zu klonen, rufen Sie die [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) -Methode der Zielpräsentation auf und geben Sie einen Folienmaster an. Dieser C#-Code zeigt, wie Sie einen Folienmaster in eine andere Präsentation klonen:

```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```


## **Mehrere Folienmaster zur Präsentation hinzufügen**
Aspose.Slides ermöglicht es Ihnen, mehrere Folienmaster und Folienlayouts zu einer beliebigen gegebenen Präsentation hinzuzufügen. Dies ermöglicht es Ihnen, Stile, Layouts und Formatierungsoptionen für Präsentationsfolien auf viele Arten einzurichten. 

In PowerPoint können Sie neue Folienmaster und Layouts (über das Menü "Folienmaster") auf folgende Weise hinzufügen:

![todo:image_alt_text](slide-master_9.jpg)

Mit Aspose.Slides können Sie einen neuen Folienmaster hinzufügen, indem Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) -Methode aufrufen:

```c#
pres.Masters.AddClone(pres.Masters[0]);
```


## **Folienmaster vergleichen**
Ein Folienmaster implementiert das [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) -Interface mit der enthaltenen [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals) -Methode, die dann verwendet werden kann, um Folien zu vergleichen. Sie gibt `true` zurück, wenn die Folienmaster in Struktur und statischem Inhalt identisch sind. 

Zwei Folienmaster sind gleich, wenn ihre Formen, Stile, Texte, Animationen und andere Einstellungen usw. gleich sind. Der Vergleich berücksichtigt keine eindeutigen Identifikatorwerte (z. B. SlideId) und dynamischen Inhalt (z. B. den aktuellen Datumswert im Datumsplatzhalter). 


## **Folienmaster als Standardansicht der Präsentation festlegen**
Aspose.Slides ermöglicht es Ihnen, einen Folienmaster als Standardansicht für eine Präsentation festzulegen. Die Standardansicht ist das, was Sie sehen, wenn Sie eine Präsentation öffnen. 

Dieser Code zeigt Ihnen, wie Sie einen Folienmaster als Standardansicht einer Präsentation in C# festlegen:

```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```

## **Unbenutzten Folienmaster entfernen**

Aspose.Slides bietet die [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) -Methode (aus der [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) -Klasse), um Ihnen zu ermöglichen, unerwünschte und ungenutzte Folienmaster zu löschen. Dieser C#-Code zeigt, wie Sie einen Folienmaster aus einer PowerPoint-Präsentation entfernen:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```