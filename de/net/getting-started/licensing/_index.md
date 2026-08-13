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
description: "Lizenzverwaltung, -anwendung und -fehlerbehebung in Aspose.Slides für .NET. Gewährleisten Sie ununterbrochenen Zugriff auf alle Funktionen mit unserem schrittweisen Lizenzierungsleitfaden."
---
## **Übersicht**

Aspose.Slides kann im Evaluierungsmodus oder mit einer gültigen Lizenz verwendet werden. Die Evaluierungsversion bietet dieselbe Funktionalität wie die lizenzierte Version, fügt jedoch ein Evaluierungswasserzeichen hinzu, wenn Präsentationen geöffnet oder gespeichert werden, und beschränkt die Textextraktion auf eine Folie.

Dieser Artikel erklärt, wie die Lizenzierung in Aspose.Slides funktioniert und wie eine Lizenz vor der Verwendung der Bibliothek angewendet wird. Eine Lizenz kann aus einer Datei, einem Stream oder einer eingebetteten Ressource mithilfe der `License`‑Klasse geladen werden. Der Artikel zeigt zudem, wie man prüft, ob eine Lizenz korrekt angewendet wurde.

## **Aspose.Slides evaluieren**

{{% alert color="info" %}} 

Sie können eine Evaluierungsversion von **Aspose.Slides für .NET** von [ihrer NuGet-Downloadseite](https://www.nuget.org/packages/Aspose.Slides.NET/) herunterladen. Die Evaluierungsversion bietet dieselben Funktionalitäten wie die lizenzierte Version des Produkts. Das Evaluierungspaket ist identisch mit dem gekauften Paket. Die Evaluierungsversion wird einfach lizenziert, sobald Sie ein paar Codezeilen hinzufügen (um die Lizenz anzuwenden).

Sobald Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie [eine Lizenz erwerben](https://purchase.aspose.com/buy). Wir empfehlen, die verschiedenen Abonnementtypen zu prüfen. Bei Fragen kontaktieren Sie das Vertriebsteam von Aspose.

Jede Aspose‑Lizenz beinhaltet ein einjähriges Abonnement für kostenlose Updates auf neue Versionen oder Fehlerbehebungen, die innerhalb des Abonnementzeitraums veröffentlicht werden. Nutzer mit lizenzierten Produkten oder sogar Evaluierungsversionen erhalten kostenlosen und unbegrenzten technischen Support.

{{% /alert %}} 

**Einschränkungen der Evaluierungsversion**

* Während die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) die volle Produktfunktionalität bietet, fügt sie bei Öffnen und Speichern ein Evaluierungswasserzeichen oben im Dokument ein. 
* Die Textextraktion aus Präsentationsfolien ist auf eine Folie beschränkt.

{{% alert color="info" %}} 

Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie auf der Seite [Wie man eine temporäre Lizenz erhält](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Lizenzierung in Aspose.Slides**
* Eine Evaluierungsversion wird lizenziert, nachdem Sie eine Lizenz erworben und ein paar Codezeilen hinzugefügt haben (um die Lizenz anzuwenden).
* Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie Produktname, Anzahl der lizenzierten Entwickler, Ablaufdatum des Abonnements usw. enthält. 
* Die Lizenzdatei ist digital signiert, daher darf sie nicht verändert werden. Selbst das versehentliche Hinzufügen eines zusätzlichen Zeilenumbruchs zum Inhalt der Datei macht sie ungültig.
* Aspose.Slides für .NET sucht die Lizenz typischerweise an folgenden Orten:
  * Ein expliziter Pfad
  * Der Ordner, der die DLL der Komponente enthält (in Aspose.Slides enthalten)
  * Der Ordner, der die Assembly enthält, die die DLL der Komponente aufgerufen hat (in Aspose.Slides enthalten)
  * Der Ordner, der die Entry‑Assembly enthält (Ihre .exe)
  * Eine eingebettete Ressource in der Assembly, die die DLL der Komponente aufgerufen hat (in Aspose.Slides enthalten).
* Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie vor der Verwendung von Aspose.Slides eine Lizenz setzen. Eine Lizenz muss nur einmal pro Anwendung oder Prozess gesetzt werden.

{{% alert color="info" %}} 

Vielleicht möchten Sie sich [Metered Licensing](https://docs.aspose.com/slides/de/net/metered-licensing/) ansehen.

{{% /alert %}} 


## **Lizenz anwenden**
Eine Lizenz kann aus einer **Datei**, einem **Stream** oder einer **eingebetteten Ressource** geladen werden. 

{{% alert color="info" %}}

Aspose.Slides stellt die Klasse [License](https://reference.aspose.com/slides/de/net/aspose.slides/license) für Lizenzvorgänge bereit.

{{% /alert %}} 

{{% alert color="warning" %}} 

Neue Lizenzen können Aspose.Slides nur ab Version 21.4 oder höher aktivieren. Ältere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.

{{% /alert %}}

### **Datei**
Die einfachste Methode, eine Lizenz zu setzen, besteht darin, die Lizenzdatei im selben Ordner wie die DLL der Komponente (in Aspose.Slides enthalten) abzulegen und nur den Dateinamen ohne Pfad anzugeben.

Dieser C#‑Code zeigt, wie man eine Lizenzdatei setzt:

``` csharp
// Instanziiert die Lizenzklasse 
Aspose.Slides.License license = new Aspose.Slides.License();

// Setzt den Pfad zur Lizenzdatei
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf der [SetLicense](https://reference.aspose.com/slides/de/net/aspose.slides/license/setlicense/#setlicense_1)-Methode der Lizenzdateiname am Ende des angegebenen expliziten Pfads mit dem Ihrer Lizenzdatei übereinstimmen.

Zum Beispiel können Sie den Lizenzdateinamen in *Aspose.Slides.lic.xml* ändern. Dann müssen Sie in Ihrem Code den Pfad zur Datei (der mit *Aspose.Slides.lic.xml* endet) an die [SetLicense](https://reference.aspose.com/slides/de/net/aspose.slides/license/setlicense/#setlicense_1)-Methode übergeben.

{{% /alert %}}

### **Stream**
Sie können eine Lizenz aus einem Stream laden. Dieser C#‑Code zeigt, wie man eine Lizenz aus einem Stream anwendet:

``` csharp
// Instanziiert die Lizenzklasse
Aspose.Slides.License license = new Aspose.Slides.License();

// Öffnet die Lizenzdatei als Stream
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Setzt die Lizenz über einen Stream
license.SetLicense(licenseStream);
```

### **Eingebettete Ressource**
Sie können die Lizenz mit Ihrer Anwendung paketieren (um ein Verlust zu vermeiden), indem Sie die Lizenz als eingebettete Ressource in eine der Assemblies einbinden, die die DLL der Komponente aufrufen (in Aspose.Slides enthalten). 

So fügen Sie eine Lizenzdatei als eingebettete Ressource hinzu:

1. In Visual Studio fügen Sie die Lizenzdatei (.lic) dem Projekt wie folgt hinzu: Gehen Sie zu **Datei** > **Vorhandenes Element hinzufügen** > **Hinzufügen**. 
2. Wählen Sie die Datei im **Solution Explorer** aus.
3. Im Fenster **Eigenschaften** setzen Sie **Build Action** auf **Embedded Resource**.
4. Um auf die in der Assembly eingebettete Lizenz zuzugreifen, fügen Sie die Lizenzdatei als eingebettete Ressource dem Projekt hinzu und übergeben dann den Lizenzdateinamen an die `SetLicense`‑Methode. 


Die Klasse `License` findet die Lizenzdatei automatisch in den eingebetteten Ressourcen. Sie müssen die Methoden `GetExecutingAssembly` und `GetManifestResourceStream` der Klasse `System.Reflection.Assembly` im Microsoft .NET Framework nicht aufrufen.

Dieser C#‑Code zeigt, wie man eine Lizenz als eingebettete Ressource setzt:

``` csharp
// Instanziiert die Lizenzklasse
Aspose.Slides.License license = new Aspose.Slides.License();

// Übergibt den in der Assembly eingebetteten Lizenzdateinamen
license.SetLicense("Aspose.Slides.lic");
```

## **Lizenz validieren**

Um zu prüfen, ob eine Lizenz korrekt gesetzt wurde, können Sie sie validieren. Dieser C#‑Code zeigt, wie man eine Lizenz validiert:

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

{{% alert title="Note" color="warning" %}} 

Die Methode [license.SetLicense](https://reference.aspose.com/slides/de/net/aspose.slides/license/setlicense/) ist nicht threadsicher. Wenn diese Methode gleichzeitig aus vielen Threads aufgerufen werden muss, sollten Sie Synchronisations‑Primitiven (wie ein Lock) verwenden, um Probleme zu vermeiden. 

{{% /alert %}}

## **FAQ**

### Kann ich die Lizenz in einer vollständig offline Umgebung (kein Internetzugang) anwenden?

Ja. Die Lizenzüberprüfung wird lokal mithilfe der Lizenzdatei durchgeführt; eine Internetverbindung ist nicht erforderlich.

### Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?

Nein. Die Lizenz ist dauerhaft: Sie können weiterhin Versionen nutzen, die vor Ihrem Abonnementende veröffentlicht wurden; Sie können jedoch neuere Versionen nur nach einer Verlängerung verwenden.