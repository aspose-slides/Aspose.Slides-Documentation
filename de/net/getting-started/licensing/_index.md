---
title: Lizenzierung
type: docs
weight: 80
url: /de/net/licensing/
keywords:
- Lizenz
- temporäre Lizenz
- Lizenz festlegen
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
description: "Lizenzen in Aspose.Slides für .NET anwenden, verwalten und Fehler beheben. Gewährleisten Sie durch unseren Schritt‑für‑Schritt‑Leitfaden einen ununterbrochenen Zugriff auf alle Funktionen."
---

## **Bewerten Sie Aspose.Slides**

{{% alert color="primary" %}} 

Sie können eine Evaluierungsversion von **Aspose.Slides for NET** von [its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.NET/) herunterladen. Die Evaluierungsversion bietet die gleichen Funktionen wie die lizenzierte Version des Produkts. Das Evaluierungspaket ist dasselbe wie das gekaufte Paket. Die Evaluierungsversion wird einfach lizenziert, nachdem Sie ein paar Codezeilen hinzugefügt haben (um die Lizenz anzuwenden).

Sobald Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie [eine Lizenz erwerben](https://purchase.aspose.com/buy). Wir empfehlen Ihnen, die verschiedenen Abonnementtypen durchzugehen. Bei Fragen kontaktieren Sie das Vertriebsteam von Aspose.

Jede Aspose-Lizenz beinhaltet ein einjähriges Abonnement für kostenlose Upgrades auf neue Versionen oder Fehlerbehebungen, die innerhalb des Abonnementzeitraums veröffentlicht werden. Benutzer mit lizenzierten Produkten oder sogar Evaluierungsversionen erhalten kostenlosen und unbegrenzten technischen Support.

{{% /alert %}} 

**Einschränkungen der Evaluierungsversion**

* Während die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) die volle Produktfunktionalität bietet, fügt sie bei Öffnungs- und Speicheroperationen ein Evaluierungs‑Wasserzeichen oben im Dokument ein. 
* Beim Extrahieren von Texten aus Präsentationsfolien sind Sie auf eine Folie beschränkt.

{{% alert color="primary" %}} 

Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑Tage‑Zwischenlizenz** anfordern. Weitere Informationen finden Sie auf der Seite [How to get a Temporary License](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Lizenzierung in Aspose.Slides**
* Eine Evaluierungsversion wird lizenziert, nachdem Sie eine Lizenz erworben und ein paar Codezeilen hinzugefügt haben (um die Lizenz anzuwenden).
* Die Lizenz ist eine Klartext‑XML‑Datei, die Details wie den Produktnamen, die Anzahl der lizenzierten Entwickler, das Ablaufdatum des Abonnements usw. enthält. 
* Die Lizenzdatei ist digital signiert, daher dürfen Sie die Datei nicht verändern. Selbst das versehentliche Hinzufügen eines zusätzlichen Zeilenumbruchs zum Inhalt der Datei macht sie ungültig.
* Aspose.Slides für .NET versucht typischerweise, die Lizenz an folgenden Orten zu finden:
  * Einen expliziten Pfad
  * Den Ordner, der die DLL der Komponente enthält (in Aspose.Slides enthalten)
  * Den Ordner, der die Assembly enthält, die die DLL der Komponente aufgerufen hat (in Aspose.Slides enthalten)
  * Den Ordner, der die Einstiegassembly enthält (Ihre .exe)
  * Eine eingebettete Ressource in der Assembly, die die DLL der Komponente aufgerufen hat (in Aspose.Slides enthalten).
* Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie eine Lizenz festlegen, bevor Sie Aspose.Slides verwenden. Sie müssen die Lizenz nur einmal pro Anwendung oder Prozess festlegen.

{{% alert color="primary" %}} 

Vielleicht möchten Sie sich [Metered Licensing](https://docs.aspose.com/slides/net/metered-licensing/) ansehen.

{{% /alert %}} 


## **Lizenz anwenden**
Eine Lizenz kann aus einer **Datei**, einem **Stream** oder einer **eingebetteten Ressource** geladen werden. 

{{% alert color="primary" %}}

Aspose.Slides stellt die Klasse [License](https://reference.aspose.com/slides/net/aspose.slides/license) für Lizenzvorgänge bereit.

{{% /alert %}} 

{{% alert color="warning" %}} 

Neue Lizenzen können Aspose.Slides nur mit Version 21.4 oder später aktivieren. Ältere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.

{{% /alert %}}

### **Datei**
Die einfachste Methode, eine Lizenz festzulegen, besteht darin, die Lizenzdatei im selben Ordner wie die DLL der Komponente (in Aspose.Slides enthalten) zu platzieren und nur den Dateinamen ohne Pfad anzugeben.

Dieser C#‑Code zeigt, wie Sie eine Lizenzdatei festlegen:
``` csharp
// Instanziiert die Lizenzklasse 
Aspose.Slides.License license = new Aspose.Slides.License();

// Setzt den Pfad der Lizenzdatei
license.SetLicense("Aspose.Slides.lic");
```


{{% alert color="warning" %}} 

Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf der Methode [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1) der Lizenzdateiname am Ende des angegebenen Pfads exakt dem Namen Ihrer Lizenzdatei entsprechen.

Beispielweise können Sie den Lizenzdateinamen zu *Aspose.Slides.lic.xml* ändern. Dann müssen Sie in Ihrem Code den Pfad zur Datei (der mit *Aspose.Slides.lic.xml* endet) an die Methode [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1) übergeben.

{{% /alert %}}

### **Stream**
Sie können eine Lizenz aus einem Stream laden. Dieser C#‑Code zeigt, wie Sie eine Lizenz aus einem Stream anwenden:
``` csharp
// Instanziert die Lizenzklasse 
Aspose.Slides.License license = new Aspose.Slides.License();

// Setzt die Lizenz über einen Stream
license.SetLicense(myStream);
```


### **Eingebettete Ressource**
Sie können die Lizenz mit Ihrer Anwendung bündeln (um sie nicht zu verlieren), indem Sie die Lizenz als eingebettete Ressource in eine der Assemblies einfügen, die die DLL der Komponente aufrufen (in Aspose.Slides enthalten). 

So fügen Sie eine Lizenzdatei als eingebettete Ressource hinzu:

1. In Visual Studio fügen Sie die Lizenzdatei (.lic) dem Projekt wie folgt hinzu: Gehen Sie über **File** > **Add Existing Item** > **Add**. 
2. Wählen Sie die Datei im **Solution Explorer** aus.
3. Im Fenster **Properties** setzen Sie **Build Action** auf **Embedded Resource**.
4. Um auf die in der Assembly eingebettete Lizenz zuzugreifen, fügen Sie die Lizenzdatei als eingebettete Ressource dem Projekt hinzu und übergeben anschließend den Lizenzdateinamen an die `SetLicense`‑Methode. 

Die Klasse `License` findet die Lizenzdatei automatisch in den eingebetteten Ressourcen. Sie müssen die Methoden `GetExecutingAssembly` und `GetManifestResourceStream` der Klasse `System.Reflection.Assembly` im Microsoft .NET Framework nicht aufrufen.

Dieser C#‑Code zeigt, wie Sie eine Lizenz als eingebettete Ressource festlegen:
``` csharp
// Instanziert die Lizenzklasse
Aspose.Slides.License license = new Aspose.Slides.License();

// Übergibt den in der Assembly eingebetteten Lizenzdateinamen
license.SetLicense("Aspose.Slides.lic");
```


## **Lizenz validieren**

Um zu prüfen, ob eine Lizenz korrekt festgelegt wurde, können Sie sie validieren. Dieser C#‑Code zeigt, wie Sie eine Lizenz validieren:
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

Die Methode [license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/) ist nicht thread‑sicher. Wenn diese Methode gleichzeitig von vielen Threads aufgerufen werden muss, sollten Sie Synchronisations‑Primitiven (wie ein lock) verwenden, um Probleme zu vermeiden. 

{{% /alert %}}

## **FAQ**

**Kann ich die Lizenz in einer vollständig offline Umgebung (kein Internetzugang) anwenden?**

Ja. Die Lizenzvalidierung erfolgt lokal mittels der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

**Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?**

Nein. Die Lizenz ist unbefristet: Sie können weiterhin Versionen verwenden, die vor dem Ende Ihres Abonnements veröffentlicht wurden; Sie können jedoch neuere Releases nur nach einer Verlängerung nutzen.