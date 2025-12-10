---
title: "Verwalten von Folienmastern in Präsentationen für .NET"
linktitle: "Folienmaster"
type: docs
weight: 80
url: /de/net/slide-master/
keywords:
- "Folienmaster"
- "Masterfolie"
- "PPT-Masterfolie"
- "mehrere Masterfolien"
- "Masterfolien vergleichen"
- "Hintergrund"
- "Platzhalter"
- "Masterfolie klonen"
- "Masterfolie kopieren"
- "Masterfolie duplizieren"
- "unbenutzte Masterfolie"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Verwalten von Folienmastern in Aspose.Slides für .NET: Erstellen, Bearbeiten und Anwenden von Layouts, Designs und Platzhaltern auf PPT, PPTX und ODP mit prägnanten C#‑Beispielen."
---

## **Was ist ein Folienmaster in PowerPoint**
Ein **Slide Master** in PowerPoint ist ein Feature, das das Layout, die Schriftarten und Stile über mehrere Folien hinweg steuert. Es hilft, Konsistenz und Markenbildung in Präsentationen zu wahren. Wenn Sie eine Präsentation (oder eine Reihe von Präsentationen) mit demselben Stil und derselben Vorlage für Ihr Unternehmen erstellen möchten, können Sie einen Folienmaster verwenden. 

Ein Folienmaster ist nützlich, weil er es Ihnen ermöglicht, das Aussehen aller Präsentationsfolien auf einmal festzulegen und zu ändern. Aspose.Slides unterstützt den Slide Master‑Mechanismus von PowerPoint. 

VBA ermöglicht es Ihnen ebenfalls, einen Folienmaster zu manipulieren und dieselben Vorgänge auszuführen, die in PowerPoint unterstützt werden: Hintergründe ändern, Formen hinzufügen, das Layout anpassen usw. Aspose.Slides bietet flexible Mechanismen, um Folienmaster zu verwenden und grundlegende Aufgaben damit durchzuführen. 

Dies sind grundlegende Folienmaster‑Operationen:

- Folienmaster erstellen.
- Folienmaster auf Präsentationsfolien anwenden.
- Hintergrund des Folienmasters ändern. 
- Bild, Platzhalter, SmartArt usw. zum Folienmaster hinzufügen.

Dies sind weiterführende Operationen mit Folienmaster: 

- Folienmaster vergleichen.
- Folienmaster zusammenführen.
- Mehrere Folienmaster anwenden.
- Folie mit Folienmaster in eine andere Präsentation kopieren.
- Duplizierte Folienmaster in Präsentationen finden.
- Folienmaster als Standardansicht der Präsentation festlegen.

{{% alert color="primary" %}} 

Vielleicht möchten Sie Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) ansehen, da er eine Live‑Implementierung einiger der hier beschriebenen Kernprozesse ist.

{{% /alert %}} 


## **Wie wird ein Folienmaster angewendet**
Bevor Sie mit einem Folienmaster arbeiten, sollten Sie verstehen, wie sie in Präsentationen verwendet und auf Folien angewendet werden. 

* Jede Präsentation enthält standardmäßig mindestens einen Folienmaster. 
* Eine Präsentation kann mehrere Folienmaster enthalten. Sie können mehrere Folienmaster hinzufügen und sie verwenden, um verschiedene Teile einer Präsentation unterschiedlich zu gestalten. 

In **Aspose.Slides** wird ein Folienmaster durch den Typ [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) dargestellt. 

Das [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekt von Aspose.Slides enthält die [**Masters**](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters)-Liste vom Typ [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), die eine Liste aller in einer Präsentation definierten Folienmaster enthält. 

Zusätzlich zu CRUD‑Operationen enthält das Interface [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) nützliche Methoden: [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) und [**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone). Diese Methoden stammen aus der grundlegenden Folienklon‑Funktion, erlauben jedoch bei Folienmastern komplizierte Setups. 

Wenn einer neuen Folie einer Präsentation hinzugefügt wird, wird automatisch ein Folienmaster darauf angewendet. Standardmäßig wird der Folienmaster der vorherigen Folie ausgewählt. 

**Hinweis**: Präsentationsfolien werden in der [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)-Liste gespeichert, und jede neue Folie wird standardmäßig am Ende der Sammlung hinzugefügt. Wenn eine Präsentation nur einen Folienmaster enthält, wird dieser Folienmaster für alle neuen Folien ausgewählt. Deshalb müssen Sie den Folienmaster nicht für jede neu erstellte Folie definieren.

Das Prinzip ist dasselbe für PowerPoint und Aspose.Slides. In PowerPoint können Sie beim Hinzufügen einer neuen Folie einfach auf die untere Zeile unter der letzten Folie klicken; dann wird eine neue Folie (mit dem Folienmaster der letzten Präsentation) erstellt:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides können Sie die äquivalente Aufgabe mit der [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone)‑Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse ausführen.


## **Folienmaster in der Folienhierarchie**
Die Verwendung von Folienlayouts mit Folienmaster ermöglicht maximale Flexibilität. Ein Folienlayout erlaubt es Ihnen, dieselben Stile wie beim Folienmaster (Hintergrund, Schriftarten, Formen usw.) festzulegen. Wenn mehrere Folienlayouts auf einem Folienmaster kombiniert werden, entsteht ein neuer Stil. Wenn Sie ein Folienlayout auf eine einzelne Folie anwenden, können Sie dessen Stil vom Folienmaster überschreiben.

Folienmaster steht über allen Einrichtungselementen: Folienmaster → Folienlayout → Folie:

![todo:image_alt_text](slide-master_2)



Jedes [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide)-Objekt hat eine [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides)-Eigenschaft mit einer Liste von Folienlayouts. Ein [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide)-Typ hat eine [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide)-Eigenschaft, die auf ein auf die Folie angewendetes Folienlayout verweist. Die Interaktion zwischen einer Folie und dem Folienmaster erfolgt über ein Folienlayout.

{{% alert color="info" title="Hinweis" %}}

* 
   In Aspose.Slides sind alle Foliensetzungen (Folienmaster, Folienlayout und die Folie selbst) tatsächlich Folienobjekte, die das [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide)‑Interface implementieren.
* Daher können Folienmaster und Folienlayout dieselben Eigenschaften implementieren, und Sie müssen wissen, wie deren Werte auf ein [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)‑Objekt angewendet werden. Der Folienmaster wird zuerst auf eine Folie angewendet, danach das Folienlayout. Beispielsweise hat die Folie, wenn sowohl Folienmaster als auch Folienlayout einen Hintergrundwert besitzen, den Hintergrund des Folienlayouts.

{{% /alert %}}


## **Was ein Folienmaster enthält**
Um zu verstehen, wie ein Folienmaster geändert werden kann, müssen Sie seine Bestandteile kennen. Dies sind die Kern‑Eigenschaften von [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/):

- [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) – Hintergrund der Folie holen/setzen.
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) – Textstile des Folienkörpers holen/setzen.
- [Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) – Alle Formen des Folienmasters (Platzhalter, Bildrahmen usw.) holen/setzen.
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) – ActiveX‑Steuerelemente holen/setzen.
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) – Theme‑Manager holen.
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) – Header‑ und Footer‑Manager holen.

Methoden des Folienmasters:

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) – Alle Folien holen, die vom Folienmaster abhängen.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) – Ermöglicht das Erstellen eines neuen Folienmasters basierend auf dem aktuellen Folienmaster und einem neuen Theme. Der neue Folienmaster wird dann auf alle abhängigen Folien angewendet.


## **Einen Folienmaster erhalten**
In PowerPoint kann der Folienmaster über das Menü Ansicht → Folienmaster aufgerufen werden:

![todo:image_alt_text](slide-master_3.jpg)



Mit Aspose.Slides können Sie einen Folienmaster folgendermaßen abrufen:
```c#
IMasterSlide master = pres.Masters[0];
```


Das Interface [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) repräsentiert einen Folienmaster. Die Eigenschaft [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) (bezogen auf den Typ [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)) enthält eine Liste aller in der Präsentation definierten Folienmaster.


## **Ein Bild zu einem Folienmaster hinzufügen**
Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf allen Folien, die von diesem Master abhängen. 

Beispielsweise können Sie das Firmenlogo und einige Bilder auf dem Folienmaster platzieren und dann zum Folienbearbeitungsmodus zurückkehren. Das Bild sollte auf jeder Folie sichtbar sein. 

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


{{% alert color="primary" title="Siehe auch" %}} 

Weitere Informationen zum Hinzufügen von Bildern zu einer Folie finden Sie im Artikel [Picture Frame](/slides/de/net/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Einen Platzhalter zu einem Folienmaster hinzufügen**
Dies sind die Standard‑Platzhalter auf einem Folienmaster: 

* Klicken Sie, um den Master‑Titelstil zu bearbeiten
* Master‑Textstile bearbeiten
* Zweite Ebene
* Dritte Ebene 

Sie erscheinen auch auf den Folien, die auf dem Folienmaster basieren. Sie können diese Platzhalter auf einem Folienmaster bearbeiten und die Änderungen werden automatisch auf die Folien angewendet. 

In PowerPoint können Sie einen Platzhalter über den Pfad Folienmaster → Platzhalter einfügen hinzufügen:



![todo:image_alt_text](slide-master_5.png)



Betrachten wir ein komplexeres Beispiel für Platzhalter mit Aspose.Slides. Angenommen, eine Folie verwendet Platzhalter, die aus dem Folienmaster templatisiert wurden:



![todo:image_alt_text](slide-master_6.png)



Wir möchten die Titel‑ und Untertitel‑Formatierung auf dem Folienmaster folgendermaßen ändern:

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


Der Titelstil und die Formatierung werden für alle Folien, die auf dem Folienmaster basieren, geändert:



![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Siehe auch" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/net/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/net/text-formatting/)

{{% /alert %}}


## **Den Hintergrund auf einem Folienmaster ändern**
Wenn Sie die Hintergrundfarbe einer Master‑Folien ändern, erhalten alle normalen Folien in der Präsentation die neue Farbe. Dieser C#‑Code demonstriert die Operation:
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
- [Presentation Background](https://docs.aspose.com/slides/net/presentation-background/)

- [Presentation Theme](https://docs.aspose.com/slides/net/presentation-theme/)

{{% /alert %}}

## **Einen Folienmaster in eine andere Präsentation klonen**
Um einen Folienmaster in eine andere Präsentation zu klonen, rufen Sie die Methode [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) der Zielpräsentation auf und übergeben einen Folienmaster. Dieser C#‑Code zeigt, wie ein Folienmaster in eine andere Präsentation geklont wird:
```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```



## **Mehrere Folienmaster zu einer Präsentation hinzufügen**
Aspose.Slides ermöglicht das Hinzufügen mehrerer Folienmaster und Folienlayouts zu einer beliebigen Präsentation. Damit können Sie Stile, Layouts und Formatierungsoptionen für Präsentationsfolien auf vielfältige Weise festlegen. 

In PowerPoint können Sie neue Folienmaster und Layouts (über das „Folienmaster‑Menü”) wie folgt hinzufügen:

![todo:image_alt_text](slide-master_9.jpg)

Mit Aspose.Slides können Sie einen neuen Folienmaster hinzufügen, indem Sie die Methode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) aufrufen:
```c#
pres.Masters.AddClone(pres.Masters[0]);
```



## **Folienmaster vergleichen**
Ein Master‑Slide implementiert das [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide)-Interface mit der [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals)-Methode, die zum Vergleich von Folien verwendet werden kann. Sie liefert `true` für Master‑Slides, die in Struktur und statischem Inhalt identisch sind. 

Zwei Master‑Slides sind gleich, wenn ihre Formen, Stile, Texte, Animationen und sonstigen Einstellungen usw. gleich sind. Der Vergleich berücksichtigt keine eindeutigen Bezeichnerwerte (z. B. SlideId) und keinen dynamischen Inhalt (z. B. aktuelles Datum in einem Datums‑Platzhalter). 


## **Einen Folienmaster als Standardansicht der Präsentation festlegen**
Aspose.Slides ermöglicht das Festlegen eines Folienmasters als Standardansicht einer Präsentation. Die Standardansicht ist das, was Sie zuerst sehen, wenn Sie eine Präsentation öffnen. 

Dieser Code zeigt, wie ein Folienmaster in C# als Standardansicht einer Präsentation festgelegt wird:
```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```


## **Ungenutzte Master‑Slides entfernen**

Aspose.Slides stellt die Methode [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (aus der Klasse [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) zur Verfügung, um unerwünschte und ungenutzte Master‑Slides zu löschen. Dieser C#‑Code zeigt, wie ein Master‑Slide aus einer PowerPoint‑Präsentation entfernt wird:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Was ist ein Folienmaster in PowerPoint?**

Ein Folienmaster ist eine Folienvorlage, die Layout, Stile, Designs, Schriftarten, Hintergrund und andere Eigenschaften für Folien in einer Präsentation definiert. Er ermöglicht das gleichzeitige Festlegen und Ändern des Aussehens aller Präsentationsfolien.  

**Wie wird ein Folienmaster in einer Präsentation angewendet?**

Jede Präsentation enthält standardmäßig mindestens einen Folienmaster. Beim Hinzufügen einer neuen Folie wird automatisch ein Folienmaster darauf angewendet, meist der Master der vorherigen Folie. Eine Präsentation kann mehrere Folienmaster enthalten, um verschiedene Teile individuell zu gestalten.  

**Welche Elemente können in einem Folienmaster angepasst werden?**

Ein Folienmaster besteht aus mehreren Kern‑Eigenschaften, die angepasst werden können:

- **Background**: Hintergrund der Folie festlegen.
- **BodyStyle**: Textstile für den Folienkörper definieren.
- **Shapes**: Alle Formen auf dem Folienmaster verwalten, einschließlich Platzhaltern und Bildrahmen.
- **Controls**: ActiveX‑Steuerelemente handhaben.
- **ThemeManager**: Zugriff auf den Theme‑Manager.
- **HeaderFooterManager**: Header‑ und Footer‑Verwaltung.  

**Wie kann ich ein Bild zu einem Folienmaster hinzufügen?**

Das Hinzufügen eines Bildes zu einem Folienmaster sorgt dafür, dass es auf allen Folien erscheint, die von diesem Master abhängen. Beispielsweise wird ein Firmenlogo, das Sie auf dem Folienmaster platzieren, auf jeder Folie der Präsentation angezeigt.  

**Wie stehen Folienmaster zu Folienlayouts?**

Folienlayouts arbeiten zusammen mit Folienmastern, um Flexibilität im Foliendesign zu bieten. Während ein Folienmaster globale Stile und Designs definiert, ermöglichen Folienlayouts Variationen in der Anordnung des Inhalts. Die Hierarchie lautet:

- **Folienmaster** → Definiert globale Stile.
- **Folienlayout** → Bietet unterschiedliche Inhaltsanordnungen.
- **Folie** → Erbt das Design von ihrem Folienlayout.

**Kann ich mehrere Folienmaster in einer einzigen Präsentation haben?**

Ja, eine Präsentation kann mehrere Folienmaster enthalten. Das erlaubt das Gestalten verschiedener Abschnitte einer Präsentation auf unterschiedliche Weise und bietet Flexibilität im Design.  

**Wie greife ich auf einen Folienmaster zu und ändere ihn mit Aspose.Slides?**

In Aspose.Slides wird ein Folienmaster durch das `IMasterSlide`‑Interface repräsentiert. Sie können einen Folienmaster über die `Masters`‑Eigenschaft des `Presentation`‑Objekts abrufen.