---
title: Präsentationen als HTML mit extern verknüpften Bildern exportieren
type: docs
weight: 50
url: /de/cpp/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

Dieser Artikel beschreibt eine fortgeschrittene Technik, die es ermöglicht zu steuern, welche Ressourcen in die resultierende HTML-Datei eingebettet werden und welche extern gespeichert und aus der HTML-Datei referenziert werden.

{{% /alert %}} 
## **Hintergrund**
Das Standardverhalten beim HTML-Export besteht darin, jede Ressource in die HTML-Datei einzubetten. Ein solches Vorgehen führt zu einer einzelnen HTML-Datei, die leicht angezeigt und verteilt werden kann. Alle notwendigen Ressourcen sind base64-kodiert enthalten. Dieses Vorgehen hat jedoch zwei Nachteile:

- Die Größe der Ausgabedatei ist aufgrund der base64-Kodierung deutlich größer. Es ist schwierig, die im Datei enthaltenen Bilder zu ersetzen.

In diesem Artikel werden wir sehen, wie wir das Standardverhalten mit **Aspose.Slides für C++** ändern können, um die Bilder extern zu verknüpfen, anstatt sie in die HTML-Datei einzubetten. Wir werden das [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller) -Interface verwenden, das drei Methoden enthält, um den Prozess der Ressourceneinbettung und -speicherung zu steuern. Dieses Interface können wir dem Konstruktor der [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) -Klasse beim Vorbereiten des Exports übergeben.

Im Folgenden der vollständige Code der **LinkController** -Klasse, die das [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller) -Interface implementiert. Wie bereits erwähnt, muss der **LinkController** das [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller) -Interface implementieren. Dieses Interface spezifiziert drei Methoden:

- **LinkEmbedDecision GetObjectStoringLocation(int32_t id, ArrayPtr<uint8_t> entityData, String semanticName, String contentType, String recomendedExtension)** Diese Methode wird aufgerufen, wenn der Exporteur eine Ressource findet und entscheiden muss, wie sie gespeichert werden soll. Die wichtigsten Parameter sind ‘id’ – der eindeutige Bezeichner der Ressource für die gesamte Exportoperation und ‘contentType’ – der den MIME-Typ der Ressource enthält. Wenn wir uns entscheiden, die Ressource zu verknüpfen, sollten wir LinkEmbedDecision::Link aus dieser Methode zurückgeben. Andernfalls sollte LinkEmbedDecision::Embed zurückgegeben werden, um die Ressource einzubetten.
- **String GetUrl(int32_t id, int32_t referrer)**
  Diese Methode wird aufgerufen, um die Ressourcen-URL in der Form zu erhalten, wie sie im resultierenden Dokument verwendet wird, z. B. für ein ```<img src="%method_result_here%">``` Tag. Die Ressource wird durch ‘id’ identifiziert.
- **SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData)** 
  Die letzte Methode der Sequenz wird aufgerufen, wenn es darum geht, die Ressource extern zu speichern. Wir haben den Ressourcenbezeichner und den Ressourceninhalt als Byte-Array. Es liegt an uns, was wir mit den bereitgestellten Ressourcedaten machen.

``` cpp
/// <summary>
/// Diese Klasse ist verantwortlich für die Entscheidungen über die extern gespeicherten Ressourcen.
/// Sie muss das Aspose::Slides::Export::ILinkEmbedController-Interface implementieren.
/// </summary>
class LinkController : public ILinkEmbedController
{
public:
    LinkController()
    {
        m_externalImages = System::MakeObject<Dictionary<int32_t, String>>();
    }
    LinkController::LinkController(String savePath) : LinkController()
    {
        m_savePath = savePath;
    }

    LinkEmbedDecision GetObjectStoringLocation(int32_t id, ArrayPtr<uint8_t> entityData, 
        String semanticName, String contentType, String recomendedExtension) override
    {
        // Hier treffen wir die Entscheidung über die externe Speicherung von Bildern.
        // Die id ist der eindeutige Identifikator jedes Objekts während der gesamten Exportoperation.

        String template_;

        // Das s_templates-Wörterbuch enthält die Inhaltstypen, die wir extern speichern und das entsprechende Dateinamen-Template.
        if (s_templates->TryGetValue(contentType, template_))
        {
            // Speichern Sie diese Ressource in der Exportliste
            m_externalImages->Add(id, template_);
            return LinkEmbedDecision::Link;
        }

        // Alle anderen Ressourcen, falls vorhanden, werden eingebettet
        return LinkEmbedDecision::Embed;
    }

    String GetUrl(int32_t id, int32_t referrer) override
    {
        // Hier konstruieren wir die Ressourcenreferenzzeichenfolge, um das Tag: <img src="%result%"> zu bilden
        // Wir müssen das Wörterbuch überprüfen, um unnötige Ressourcen herauszufiltern.
        // Während wir überprüfen, extrahieren wir das entsprechende Dateinamen-Template.
        String template_;
        if (m_externalImages->TryGetValue(id, template_))
        {
            // Angenommen, wir werden die Ressourcen-Dateien direkt neben der HTML-Datei speichern.
            // Das Bild-Tag sieht dann so aus: <img src="image-1.png"> mit der entsprechenden Ressourcen-ID und -Erweiterung.
            String fileUrl = String::Format(template_, id);
            return fileUrl;
        }

        // null muss für die weiterhin eingebetteten Ressourcen zurückgegeben werden
        return nullptr;
    }

    void SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData) override
    {
        // Hier speichern wir tatsächlich die Ressourcen-Dateien auf der Festplatte.
        // Wiederum Überprüfung des Wörterbuchs. Wenn die id hier nicht gefunden wird, ist das ein Zeichen für einen Fehler in den GetObjectStoringLocation- oder GetUrl-Methoden.
        if (m_externalImages->ContainsKey(id))
        {
            // Jetzt verwenden wir den im Wörterbuch gespeicherten Dateinamen und kombinieren ihn nach Bedarf mit einem Pfad.

            // Konstruktion des Dateinamens unter Verwendung des gespeicherten Templates und der Id.
            String fileName = String::Format(m_externalImages->idx_get(id), id);
            
            // Kombinieren mit dem Speicherverzeichnis
            const String savePath = m_savePath != nullptr ? m_savePath : String::Empty;
            String filePath = Path::Combine(savePath, fileName);

            auto fs = System::MakeObject<FileStream>(filePath, FileMode::Create);
            fs->Write(entityData, 0, entityData->get_Length());
        }
        else
        {
            throw Exception(u"Etwas ist schiefgelaufen");
        }
    }

private:
    String m_savePath;
    SharedPtr<Dictionary<int32_t, String>> m_externalImages;
    static SharedPtr<Dictionary<String, String>> s_templates;

    static struct __StaticConstructor__
    {
        __StaticConstructor__()
        {
            s_templates->Add(u"image/jpeg", u"image-{0}.jpg");
            s_templates->Add(u"image/png", u"image-{0}.png");
        }
    } s_constructor__;
};
```

Nachdem wir die **LinkController** -Klasse geschrieben haben, werden wir sie nun mit der [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) -Klasse verwenden, um die Präsentation als HTML mit extern verknüpften Bildern mit dem folgenden Code zu exportieren.

``` cpp
const String templatePath = u"../templates/image.pptx";
auto pres = System::MakeObject<Presentation>(templatePath);

auto htmlOptions = System::MakeObject<HtmlOptions>(System::MakeObject<LinkController>(GetOutPath()));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(System::MakeObject<SVGOptions>()));
// Diese Zeile ist erforderlich, um die Anzeige des Folientitels im HTML zu entfernen.
// Kommentieren Sie es aus, wenn Sie die Folientitelanzeige bevorzugen.
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));

pres->Save(GetOutPath() + u"/output.html", SaveFormat::Html, htmlOptions);
```

Wir übergeben **SlideImageFormat::Svg** an die **set_SlideImageFormat** -Methode, was bedeutet, dass die resultierende HTML-Datei SVG-Daten enthält, um den Inhalt der Präsentation darzustellen.

Was die Inhaltstypen betrifft, so hängt es von den tatsächlichen Bilddaten ab, die in der Präsentation enthalten sind. Wenn es rasterisierte Bitmaps in der Präsentation gibt, muss der Klassencode bereit sein, sowohl ‘image/jpeg’ als auch ‘image/png’ Inhaltstypen zu verarbeiten. Der tatsächliche Inhaltstyp der exportierten rasterisierten Bitmaps stimmt möglicherweise nicht mit dem Inhaltstyp der in der Präsentation gespeicherten Bilder überein. Die internen Algorithmen von Aspose.Slides für C++ führen eine Größenoptimierung durch und verwenden entweder den JPG- oder PNG-Codec, je nachdem, welcher eine kleinere Datengröße erzeugt. Bilder, die einen Alphakanal (Transparenz) enthalten, werden immer als PNG kodiert.