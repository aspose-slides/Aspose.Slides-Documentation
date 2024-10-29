---
title: Warnungs-Callbacks für Schriftartenersatz in Aspose.Slides erhalten
type: docs
weight: 120
url: /de/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides für .NET ermöglicht es, Warnungs-Callbacks für den Schriftartenersatz zu erhalten, falls die verwendete Schriftart während des Renderings nicht auf dem Rechner verfügbar ist. Die Warnungs-Callbacks sind hilfreich zur Fehlersuche bei fehlenden oder nicht erreichbaren Schriftarten während des Renderings.

{{% /alert %}} 
## **Warnungs-Callbacks für Schriftartenersatz erhalten**
Aspose.Slides für .NET bietet einfache API-Methoden, um die Warnungs-Callbacks während des Renderings zu erhalten. Alles, was Sie tun müssen, ist, die folgenden Schritte zu befolgen, um die Warnungs-Callbacks auf Ihrer Seite zu konfigurieren:

1. Erstellen Sie eine benutzerdefinierte Callback-Klasse, um die Callbacks zu empfangen.
1. Setzen Sie die Warnungs-Callbacks mit der LoadOptions-Klasse.
1. Laden Sie die Präsentationsdatei, die eine Schriftart für den darin enthaltenen Text verwendet, die auf Ihrem Zielrechner nicht verfügbar ist.
1. Generieren Sie das Miniaturbild der Folie, um den Effekt zu sehen.

```c#
//Einstellen der Warnungs-Callbacks
LoadOptions lo = new LoadOptions();
lo.WarningCallback = new HandleFontsWarnings();

//Präsentation instanziieren
Presentation presentation = new Presentation("1.ppt", lo);

//Generieren des Folienminiaturbilds
foreach (ISlide slide in presentation.Slides)
{
    IImage image = slide.GetImage();
}
```

```c#
class HandleFontsWarnings : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        Console.WriteLine(warning.WarningType); // 1 - WarningType.DataLoss
        Console.WriteLine(warning.Description); // "Schriftart wird von X nach Y ersetzt"
        return ReturnAction.Continue;
    }
}
```