---
title: Exportieren von Präsentationen nach HTML mit extern verlinkten Bildern
type: docs
weight: 100
url: /net/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

Der Exportprozess von Präsentationen nach HTML ermöglicht es Ihnen, die

1. Ressourcen zu bestimmen, die in die resultierende HTML-Datei eingebettet werden
2. die Ressourcen, die extern gespeichert und aus der HTML-Datei referenziert werden.

{{% /alert %}} 

## **Hintergrund**

Das Standardverhalten des HTML-Exports besteht darin, alle Ressourcen durch Base64-Codierung in die HTML-Datei einzubetten. Ein solches Vorgehen erzeugt eine einzelne HTML-Datei, was für die Anzeige und Verteilung praktisch ist. Der Standardansatz hat die folgenden Einschränkungen:

* Die ausgegebene Datei ist aufgrund der Base64-Codierung erheblich größer als ihre Bestandteile.
* Die in der Datei enthaltenen Bilder oder Ressourcen sind schwierig zu ersetzen.

### **Ein anderer Ansatz**

Ein anderer Ansatz, der **[ILinkEmbedController](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/)** einbezieht, vermeidet die genannten Einschränkungen.  

Die Klasse `LinkController` implementiert das Interface `ILinkEmbedController`. Das Interface wird dann dem Konstruktor der Klasse [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/htmloptions/#constructor) übergeben. Das ILinkEmbedController-Interface enthält drei Methoden, die den Prozess der Ressourceneinbettung und -speicherung steuern:

**[GetObjectStoringLocation](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation)(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)**: Diese Methode wird aufgerufen, wenn der Exporteur auf eine Ressource stößt und entscheiden muss, wie die Ressource gespeichert werden soll. *id* (eindeutiger Bezeichner der Ressource für den Exportvorgang) und *contentType* (enthält den MIME-Typ der Ressource) sind die wichtigsten Parameter der Methode. Wenn Sie die Ressource verlinken möchten, müssen Sie den Enum [LinkEmbedDecision.Link](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/) aus der Methode zurückgeben. Andernfalls (um die Ressource einzubetten) müssen Sie [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/) zurückgeben.

**[GetUrl](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/geturl)(int id, int referrer)**: Diese Methode wird aufgerufen, um die Ressourcensyntax für die URL in der gleichen Form zu erhalten, wie sie in der resultierenden Datei verwendet wird. Die Ressource wird durch *id* identifiziert.

**[SaveExternal](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/saveexternal)(int id, byte[] entityData)**: Als letzte Methode in der Sequenz wird sie aufgerufen, wenn es an der Zeit ist, die Ressource extern zu speichern. Da der Ressourcenbezeichner und die Ressourceninhalte in einem Byte-Array existieren, können Sie alle Arten von Aufgaben mit den Ressourcendaten ausführen.

Dieser C#-Code für die **LinkController**-Klasse implementiert das **ILinkEmbedController**-Interface:

```c#
class LinkController : ILinkEmbedController
{
    static LinkController()
    {
        s_templates.Add("image/jpeg", "image-{0}.jpg");
        s_templates.Add("image/png", "image-{0}.png");
    }

    /// <summary>
    /// Standardparameterloser Konstruktor
    /// </summary>
    public LinkController()
    {
        m_externalImages = new Dictionary<int, string>();
    }

    /// <summary>
    /// Erstellt eine Klasseninstanz und legt den Pfad fest, an dem die generierten Ressourcen-Dateien gespeichert werden.
    /// </summary>
    /// <param name="savePath">Pfad zum Speicherort, an dem die generierten Ressourcen-Dateien gespeichert werden.</param>
    public LinkController(string savePath)
        : this()
    {
        SavePath = savePath;
    }

    /// <summary>
    /// Ein ILinkEmbedController-Mitglied
    /// </summary>
    public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName,
        string contentType,
        string recomendedExtension)
    {
        // Hier treffen wir die Entscheidung über das externe Speichern von Bildern.
        // Die id ist der eindeutige Bezeichner jedes Objekts während des gesamten Exportvorgangs.

        string template;

        // Das s_templates-Dictionary enthält Inhaltstypen, die wir extern speichern werden, und das entsprechende Dateinamenmuster.
        if (s_templates.TryGetValue(contentType, out template))
        {
            // Speichern dieser Ressource in der Exportliste
            m_externalImages.Add(id, template);
            return LinkEmbedDecision.Link;
        }

        // Alle anderen Ressourcen, falls vorhanden, werden eingebettet
        return LinkEmbedDecision.Embed;
    }

    /// <summary>
    /// Ein ILinkEmbedController-Mitglied
    /// </summary>
    public string GetUrl(int id, int referrer)
    {
        // Hier konstruieren wir die Ressourcereferenzzeichenfolge, um das Tag <img src="%result%"> zu bilden.
        // Wir müssen das Dictionary überprüfen, um unnötige Ressourcen herauszufiltern.
        // Neben der Überprüfung extrahieren wir das entsprechende Dateinamenmuster.
        string template;
        if (m_externalImages.TryGetValue(id, out template))
        {
            // Angenommen, wir speichern die Ressourcen-Dateien direkt neben der HTML-Datei.
            // Das Bild-Tag sieht dann so aus: <img src="image-1.png"> mit dem entsprechenden Ressourcen-ID und der Erweiterung.
            var fileUrl = String.Format(template, id);
            return fileUrl;
        }

        // null muss für die Ressourcen zurückgegeben werden, die weiterhin eingebettet bleiben
        return null;
    }

    /// <summary>
    /// Ein ILinkEmbedController-Mitglied
    /// </summary>
    public void SaveExternal(int id, byte[] entityData)
    {
        // Hier speichern wir tatsächlich die Ressourcen-Dateien auf der Festplatte.
        // Nochmals das Dictionary überprüfen. Wenn die ID hier nicht gefunden wird, ist das ein Zeichen für einen Fehler in den Methoden GetObjectStoringLocation oder GetUrl.
        if (m_externalImages.ContainsKey(id))
        {
            // Jetzt verwenden wir den Dateinamen, der im Dictionary gespeichert ist, und kombinieren ihn mit einem Pfad nach Bedarf.

            // Konstruktion des Dateinamens mit dem gespeicherten Template und der ID.
            var fileName = String.Format(m_externalImages[id], id);

            // Kombination mit dem Verzeichnis des Speicherorts
            var filePath = Path.Combine(SavePath ?? String.Empty, fileName);

            using (var fs = new FileStream(filePath, FileMode.Create))
                fs.Write(entityData, 0, entityData.Length);
        }
        else
            throw new Exception("Etwas ist falsch");
    }

    /// <summary>
    /// Liest oder setzt den Pfad, an dem die generierten Ressourcen-Dateien gespeichert werden.
    /// </summary>
    public string SavePath { get; set; }

    /// <summary>
    /// Ein Dictionary zur Speicherung von Zuordnungen zwischen Ressourcen-IDs und den entsprechenden Dateinamen.
    /// </summary>
    private readonly Dictionary<int, string> m_externalImages;

    /// <summary>
    /// Ein Dictionary zur Speicherung von Zuordnungen zwischen den Inhaltstypen von Ressourcen, die wir extern speichern werden,
    /// und den entsprechenden Dateinamenmustern.
    /// </summary>
    private static readonly Dictionary<string, string> s_templates = new Dictionary<string, string>();
}
```

Nachdem wir die **LinkController**-Klasse geschrieben haben, können wir sie nun zusammen mit der **HTMLOptions**-Klasse verwenden, um die Präsentation auf folgende Weise nach HTML mit extern verlinkten Bildern zu exportieren:

```c#
using (var pres = new Presentation(@"C:\data\input.pptx")) {

    var htmlOptions = new HtmlOptions(new LinkController(@"C:\data\out\"));
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(new SVGOptions());
    // Diese Zeile ist notwendig, um die Anzeige des Folientitels in HTML zu entfernen.
    // Kommentieren Sie sie aus, wenn Sie möchten, dass der Folientitel angezeigt wird.
    htmlOptions.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(String.Empty, false);

    Console.WriteLine("Export gestartet");
    pres.Save(@"C:\data\out\output.html", SaveFormat.Html, htmlOptions);
}
```

Wir haben `SlideImageFormat.Svg` der `SlideImageFormat`-Eigenschaft zugewiesen, sodass die resultierende HTML-Datei SVG-Daten enthält, um den Inhalt der Präsentation zu zeichnen.

Inhaltstypen: Wenn die Präsentation Rasterbilder enthält, muss der Klassencode zur Verarbeitung sowohl der Inhaltstypen 'image/jpeg' als auch 'image/png' vorbereitet sein. Der Inhalt der exportierten Bitmapbilder stimmt möglicherweise nicht mit dem überein, was in der Präsentation gespeichert wurde. Die internen Algorithmen von Aspose.Slides führen eine Größenoptimierung durch und verwenden entweder den JPG- oder PNG-Codec (je nachdem, welcher eine kleinere Datenmenge erzeugt). Bilder, die einen Alphakanal (Transparenz) enthalten, werden immer in PNG codiert.