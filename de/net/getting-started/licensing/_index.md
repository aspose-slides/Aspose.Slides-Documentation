---
title: Lizenzierung
type: docs
weight: 80
url: /de/net/licensing/
keywords:
- Lizenz
- temporäre Lizenz
- Lizenz setzen
- Lizenz verwenden
- Lizenz validieren
- Lizenzdatei
- Evaluierungsversion
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Lizenzierung anwenden, verwalten und Fehler beheben in Aspose.Slides für .NET. Stellen Sie ununterbrochenen Zugriff auf alle Funktionen mit unserer Schritt‑für‑Schritt‑Lizenzierungsanleitung sicher."
---
## **Übersicht**

Aspose.Slides kann im Evaluierungsmodus oder mit einer gültigen Lizenz verwendet werden. Die Evaluierungsversion bietet dieselbe Funktionalität wie die lizenzierte Version, fügt jedoch jedem gespeicherten Folienblatt ein Evaluierungswasserzeichen hinzu und kürzt Text, den Ihr Code aus Präsentationen ausliest.

Dieser Artikel erklärt, wie die Lizenzierung in Aspose.Slides funktioniert und wie Sie vor der Nutzung der Bibliothek eine Lizenz anwenden. Eine Lizenz kann aus einer Datei, einem Stream oder einer eingebetteten Ressource über die `License`‑Klasse geladen werden. Der Artikel zeigt zudem, wie Sie überprüfen können, ob eine Lizenz korrekt angewendet wurde.

## **Aspose.Slides evaluieren**

{{% alert color="info" title="Hinweis" %}}
Sie können eine Evaluierungsversion von **Aspose.Slides for .NET** von [der NuGet‑Downloadseite](https://www.nuget.org/packages/Aspose.Slides.NET/) herunterladen. Die Evaluierungsversion stellt dieselben Funktionen wie die lizenzierte Version des Produkts bereit. Das Evaluierungspaket ist identisch mit dem erworbenen Paket. Die Evaluierungsversion wird einfach lizenziert, sobald Sie ein paar Code‑Zeilen hinzufügen (um die Lizenz anzuwenden).

Sobald Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie [eine Lizenz erwerben](https://purchase.aspose.com/pricing/slides/de/net/). Wir empfehlen Ihnen, die verschiedenen Abonnement‑Typen zu prüfen. Bei Fragen kontaktieren Sie bitte das Aspose‑Verkaufsteam.

Jede Aspose‑Lizenz beinhaltet ein einjähriges Abonnement für kostenlose Upgrades auf neue Versionen oder Fehlerbehebungen, die innerhalb des Abonnement‑Zeitraums veröffentlicht werden. Nutzer mit lizenzierten Produkten oder sogar Evaluierungsversionen erhalten kostenlosen und unbegrenzten technischen Support.
{{% /alert %}} 

**Einschränkungen der Evaluierungsversion**

* Die Evaluierungsversion (ohne angegebene Lizenz) bietet die volle Produktfunktionalität, fügt jedoch jedem gespeicherten Folienblatt ein Evaluierungswasserzeichen‑Textfeld hinzu.
* Text, den Ihr Code aus einer Präsentation ausliest, wird auf die ersten Zeichen gekürzt und mit einem Hinweis auf die Evaluierungsbeschränkung versehen. Text, den Ihr Code schreibt, wird vollständig gespeichert.

{{% alert color="info" title="Hinweis" %}}
Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑Tage‑Temporäre Lizenz** anfordern. Siehe die Seite [How to get a Temporary License](https://purchase.aspose.com/temporary-license) für weitere Informationen.
{{% /alert %}}

## **Lizenzierung in Aspose.Slides**
* Eine Evaluierungsversion wird lizenziert, sobald Sie eine Lizenz kaufen und ein paar Code‑Zeilen hinzufügen (um die Lizenz anzuwenden).
* Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie Produktname, Anzahl der lizenzierten Entwickler, Ablaufdatum des Abonnements usw. enthält. 
* Die Lizenzdatei ist digital signiert, daher dürfen Sie die Datei nicht ändern. Schon das versehentliche Hinzufügen eines zusätzlichen Zeilenumbruchs zum Inhalt der Datei macht sie ungültig.
* Aspose.Slides for .NET versucht typischerweise, die Lizenz an folgenden Orten zu finden:
  * Ein expliziter Pfad
  * Der Ordner, der die DLL der Komponente enthält (enthalten in Aspose.Slides)
  * Der Ordner, der die Assembly enthält, die die DLL der Komponente aufgerufen hat (enthalten in Aspose.Slides)
  * Der Ordner, der die Entry‑Assembly enthält (Ihre .exe)
  * Eine eingebettete Ressource in der Assembly, die die DLL der Komponente aufgerufen hat (enthalten in Aspose.Slides).
* Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie vor der Verwendung von Aspose.Slides eine Lizenz setzen. Sie müssen die Lizenz nur einmal pro Anwendung oder Prozess setzen.

{{% alert color="info" title="Hinweis" %}}
Vielleicht möchten Sie sich [Metered Licensing](/slides/de/net/metered-licensing/) ansehen.
{{% /alert %}} 

## **Lizenz anwenden**
Eine Lizenz kann aus einer **Datei**, **Stream** oder **eingebetteten Ressource** geladen werden. 

{{% alert color="info" title="Hinweis" %}}
Aspose.Slides stellt die [License](https://reference.aspose.com/slides/de/net/aspose.slides/license)-Klasse für Lizenz‑Operationen bereit.
{{% /alert %}} 

{{% alert color="warning" title="Warnung" %}}
Neue Lizenzen können Aspose.Slides nur ab Version 21.4 aktivieren. Ältere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.
{{% /alert %}}

### **Datei**
Die einfachste Methode, eine Lizenz zu setzen, besteht darin, die Lizenzdatei im selben Ordner wie die DLL der Komponente (enthalten in Aspose.Slides) abzulegen und nur den Dateinamen ohne Pfad anzugeben.

Dieser C#‑Code zeigt, wie Sie eine Lizenzdatei setzen:

``` csharp
// Instanziert die License-Klasse 
Aspose.Slides.License license = new Aspose.Slides.License();

// Setzt den Pfad der Lizenzdatei
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" title="Warnung" %}}
Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf der [SetLicense](https://reference.aspose.com/slides/de/net/aspose.slides/license/setlicense/#setlicense_1)-Methode der Dateiname am Ende des angegebenen Pfades mit Ihrem Lizenzdateinamen übereinstimmen.

Beispielsweise können Sie den Lizenzdateinamen in *Aspose.Slides.lic.xml* ändern. Dann müssen Sie in Ihrem Code den Pfad zur Datei (der mit *Aspose.Slides.lic.xml* endet) an die [SetLicense](https://reference.aspose.com/slides/de/net/aspose.slides/license/setlicense/#setlicense_1)-Methode übergeben.
{{% /alert %}}

### **Stream**
Sie können eine Lizenz aus einem Stream laden. Dieser C#‑Code zeigt, wie Sie eine Lizenz aus einem Stream anwenden:

``` csharp
// Instanziert die License-Klasse
Aspose.Slides.License license = new Aspose.Slides.License();

// Öffnet die Lizenzdatei als Stream
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Setzt die Lizenz über einen Stream
license.SetLicense(licenseStream);
```

### **Eingebettete Ressource**
Sie können die Lizenz mit Ihrer Anwendung paketieren (um einen Verlust zu verhindern), indem Sie die Lizenz als eingebettete Ressource in eine der Assemblies einbinden, die die DLL der Komponente aufrufen (enthalten in Aspose.Slides). 

So fügen Sie eine Lizenzdatei als eingebettete Ressource hinzu:

1. In Visual Studio fügen Sie die Lizenzdatei (.lic) dem Projekt hinzu: **Datei** > **Vorhandenes Element hinzufügen** > **Hinzufügen**. 
2. Wählen Sie die Datei im **Solution Explorer** aus.
3. Im Fenster **Eigenschaften** setzen Sie **Build Action** auf **Embedded Resource**.
4. Um auf die in der Assembly eingebettete Lizenz zuzugreifen, fügen Sie die Lizenzdatei als eingebettete Ressource dem Projekt hinzu und übergeben dann den Lizenzdateinamen an die `SetLicense`‑Methode. 

Die `License`‑Klasse findet die Lizenzdatei automatisch in den eingebetteten Ressourcen. Sie müssen nicht die Methoden `GetExecutingAssembly` und `GetManifestResourceStream` der Klasse `System.Reflection.Assembly` im Microsoft .NET Framework aufrufen.

Dieser C#‑Code zeigt, wie Sie eine Lizenz als eingebettete Ressource setzen:

``` csharp
// Instanziert die License-Klasse
Aspose.Slides.License license = new Aspose.Slides.License();

// Übergibt den in der Assembly eingebetteten Lizenzdateinamen
license.SetLicense("Aspose.Slides.lic");
```

## **Lizenz validieren**

Um zu überprüfen, ob eine Lizenz korrekt gesetzt wurde, können Sie sie validieren. Dieser C#‑Code zeigt, wie Sie eine Lizenz validieren:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **Thread‑Sicherheit**

{{% alert color="warning" title="Warnung" %}}
Die [license.SetLicense](https://reference.aspose.com/slides/de/net/aspose.slides/license/setlicense/)-Methode ist nicht thread‑sicher. Wenn diese Methode gleichzeitig von vielen Threads aufgerufen werden muss, sollten Sie Synchronisations‑Primitive (wie ein Lock) verwenden, um Probleme zu vermeiden. 
{{% /alert %}}

## **FAQ**

### Kann ich die Lizenz in einer komplett offline‑Umgebung (kein Internetzugang) anwenden?

Ja. Die Lizenzvalidierung erfolgt lokal anhand der Lizenzdatei; es ist keine Internetverbindung erforderlich.

### Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?

Nein. Die Lizenz ist unbefristet: Sie können weiterhin Versionen nutzen, die vor dem Ende Ihres Abonnements veröffentlicht wurden; Sie können jedoch ohne Erneuerung keine neueren Releases verwenden.