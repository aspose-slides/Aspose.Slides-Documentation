---
title: Warnungs-Callbacks für Schriftartenersetzung in Aspose.Slides erhalten
type: docs
weight: 70
url: /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides für C++ ermöglicht es, Warnungs-Callbacks für Schriftartenersetzungen zu erhalten, falls die verwendete Schriftart während des Renderings nicht auf einem Rechner verfügbar ist. Die Warnungs-Callbacks sind hilfreich beim Debuggen von Problemen mit fehlenden oder nicht zugänglichen Schriftarten während des Renderings.

{{% /alert %}} 
## **Warnungs-Callbacks für Schriftartenersetzung erhalten**
Aspose.Slides für C++ bietet eine einfache API-Methode, um die Warnungs-Callbacks während des Renderings zu erhalten. Alles, was Sie tun müssen, ist, die folgenden Schritte zu befolgen, um die Warnungs-Callbacks auf Ihrer Seite zu konfigurieren:

1. Erstellen Sie eine benutzerdefinierte Callback-Klasse, um die Callbacks zu empfangen.
1. Setzen Sie die Warnungs-Callbacks mit der [LoadOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options) Klasse.
1. Laden Sie die Präsentationsdatei, die eine Schriftart für den Text enthält, die auf Ihrem Ziel-Rechner nicht verfügbar ist.
1. Generieren Sie das Miniaturbild der Folie, um die Wirkung zu sehen.

``` cpp
class HandleFontsWarnings : public Warnings::IWarningCallback
{
public:
    Warnings::ReturnAction Warning(SharedPtr<Warnings::IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == Warnings::WarningType::CompatibilityIssue)
        {
            return Warnings::ReturnAction::Continue;
        }

        // 1 - WarningType.DataLoss
        Console::WriteLine(System::ObjectExt::ToString(warning->get_WarningType()));
        // "Schriftart wird von X nach Y ersetzt"
        Console::WriteLine(warning->get_Description());

        return Warnings::ReturnAction::Continue;
    }
};
        
void Run()
{
    System::String dataDir = GetDataPath();

    // Warnungs-Callbacks setzen
    System::SharedPtr<LoadOptions> options = System::MakeObject<LoadOptions>();
    options->set_WarningCallback(System::MakeObject<HandleFontsWarnings>());

    // Präsentation instanziieren
    System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(dataDir + u"presentation.pptx", options);

    // Miniaturansichten der Folien generieren
    for (auto slide : presentation->get_Slides())
    {
        System::SharedPtr<IImage> image = slide->GetImage();
    }
}
```