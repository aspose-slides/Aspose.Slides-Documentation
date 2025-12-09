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
description: "Anwenden, Verwalten und Problembeheben von Lizenzen in Aspose.Slides für .NET. Gewährleisten Sie einen ununterbrochenen Zugriff auf alle Funktionen mit unserer Schritt-für-Schritt-Lizenzierungsanleitung."
---

## **Evaluieren Sie Aspose.Slides**

{{% alert color="primary" %}} 

Sie können eine Evaluierungsversion von **Aspose.Slides for NET** von [ihrer NuGet-Downloadseite](https://www.nuget.org/packages/Aspose.Slides.NET/) herunterladen. Die Evaluierungsversion bietet dieselben Funktionalitäten wie die lizenzierte Version des Produkts. Das Evaluierungspaket ist dasselbe wie das gekaufte Paket. Die Evaluierungsversion wird einfach lizenziert, sobald Sie ein paar Codezeilen hinzufügen (um die Lizenz anzuwenden).

Sobald Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie [eine Lizenz erwerben](https://purchase.aspose.com/buy). Wir empfehlen Ihnen, die verschiedenen Abonnementtypen zu prüfen. Bei Fragen kontaktieren Sie das Vertriebsteam von Aspose.

Jede Aspose-Lizenz beinhaltet ein einjähriges Abonnement für kostenlose Upgrades auf neue Versionen oder Fehlerbehebungen, die innerhalb des Abonnementzeitraums veröffentlicht werden. Benutzer mit lizenzierten Produkten oder sogar Evaluierungsversionen erhalten kostenlosen und unbegrenzten technischen Support.

{{% /alert %}} 

**Einschränkungen der Evaluierungsversion**

* Während die Aspose.Slides‑Evaluierungsversion (ohne angegebene Lizenz) die volle Produktfunktionalität bietet, fügt sie bei Öffnungs‑ und Speicheroperationen ein Evaluierungs‑Wasserzeichen oben im Dokument ein. 
* Sie sind beim Extrahieren von Texten aus Präsentationsfolien auf eine Folie beschränkt.

{{% alert color="primary" %}} 

Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑Tage‑Temporärlizenz** anfordern. Weitere Informationen finden Sie auf der Seite [Wie man eine temporäre Lizenz erhält](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Lizenzierung in Aspose.Slides**
* Eine Evaluierungsversion wird lizenziert, nachdem Sie eine Lizenz erworben und ein paar Codezeilen hinzugefügt haben (um die Lizenz anzuwenden).
* Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie Produktname, Anzahl der lizenzierten Entwickler, Ablaufdatum des Abonnements usw. enthält. 
* Die Lizenzdatei ist digital signiert, daher dürfen Sie die Datei nicht ändern. Sogar ein unbeabsichtigtes Hinzufügen eines zusätzlichen Zeilenumbruchs zum Inhalt der Datei macht sie ungültig.
* Aspose.Slides für .NET sucht die Lizenz in der Regel an folgenden Speicherorten:
  * Ein expliziter Pfad
  * Der Ordner, der die DLL der Komponente enthält (in Aspose.Slides enthalten)
  * Der Ordner, der die Assembly enthält, die die DLL der Komponente aufruft (in Aspose.Slides enthalten)
  * Der Ordner, der die Entry‑Assembly enthält (Ihre .exe)
  * Eine eingebettete Ressource in der Assembly, die die DLL der Komponente aufruft (in Aspose.Slides enthalten).
* Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie vor der Verwendung von Aspose.Slides eine Lizenz festlegen. Sie müssen die Lizenz nur einmal pro Anwendung oder Prozess festlegen.

{{% alert color="primary" %}} 

Vielleicht möchten Sie sich [Metered Licensing](https://docs.aspose.com/slides/net/metered-licensing/) ansehen.

{{% /alert %}} 


## **Lizenz anwenden**
Eine Lizenz kann aus einer **Datei**, einem **Stream** oder einer **eingebetteten Ressource** geladen werden. 

{{% alert color="primary" %}}

Aspose.Slides stellt die Klasse [License](https://reference.aspose.com/slides/net/aspose.slides/license) für Lizenzvorgänge bereit.

{{% /alert %}} 

{{% alert color="warning" %}} 

Neue Lizenzen können Aspose.Slides nur mit Version 21.4 oder neuer aktivieren. Ältere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.

{{% /alert %}}

### **Datei**
Die einfachste Methode, eine Lizenz festzulegen, besteht darin, die Lizenzdatei im selben Ordner wie die DLL der Komponente (in Aspose.Slides enthalten) abzulegen und nur den Dateinamen ohne Pfad anzugeben.

Dieser C#‑Code zeigt, wie man eine Lizenzdatei festlegt:
``` csharp
// Instanziiert die License-Klasse
Aspose.Slides.License license = new Aspose.Slides.License();

// Setzt den Lizenzdateipfad
license.SetLicense("Aspose.Slides.lic");
```


{{% alert color="warning" %}} 

Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf der Methode [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1) der Lizenzdateiname am Ende des angegebenen expliziten Pfads mit Ihrer Lizenzdatei übereinstimmen.

Zum Beispiel können Sie den Lizenzdateinamen zu *Aspose.Slides.lic.xml* ändern. Dann müssen Sie in Ihrem Code den Pfad zur Datei (der mit *Aspose.Slides.lic.xml* endet) an die Methode [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1) übergeben.

{{% /alert %}}

### **Stream**
Sie können eine Lizenz aus einem Stream laden. Dieser C#‑Code zeigt, wie man eine Lizenz aus einem Stream anwendet:
``` csharp
// Instanziiert die License-Klasse 
Aspose.Slides.License license = new Aspose.Slides.License();

// Setzt die Lizenz über einen Stream
license.SetLicense(myStream);
```


### **Eingebettete Ressource**
Sie können die Lizenz mit Ihrer Anwendung bündeln (um sie nicht zu verlieren), indem Sie die Lizenz als eingebettete Ressource in eine der Assemblies einfügen, die die DLL der Komponente aufrufen (in Aspose.Slides enthalten). 

So fügen Sie eine Lizenzdatei als eingebettete Ressource hinzu:

1. In Visual Studio fügen Sie die Lizenzdatei (.lic) dem Projekt wie folgt hinzu: Gehen Sie zu **Datei** > **Vorhandenes Element hinzufügen** > **Hinzufügen**. 
2. Wählen Sie die Datei im **Solution Explorer** aus.
3. Im Fenster **Eigenschaften** setzen Sie die **Build Action** auf **Embedded Resource**.
4. Um auf die in der Assembly eingebettete Lizenz zuzugreifen, fügen Sie die Lizenzdatei als eingebettete Ressource zum Projekt hinzu und übergeben dann den Lizenzdateinamen an die Methode `SetLicense`. 

Die Klasse `License` findet die Lizenzdatei automatisch in den eingebetteten Ressourcen. Sie müssen die Methoden `GetExecutingAssembly` und `GetManifestResourceStream` der Klasse `System.Reflection.Assembly` im Microsoft .NET Framework nicht aufrufen.

Dieser C#‑Code zeigt, wie man eine Lizenz als eingebettete Ressource festlegt:
``` csharp
// Instanziiert die License-Klasse
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

Die Methode [license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/) ist nicht threadsicher. Wenn diese Methode gleichzeitig von vielen Threads aufgerufen werden muss, sollten Sie Synchronisations‑primitive (wie ein lock) verwenden, um Probleme zu vermeiden. 

{{% /alert %}}

## **FAQ**

**Kann ich die Lizenz in einer völlig offline‑Umgebung (kein Internetzugang) anwenden?**

Ja. Die Lizenzvalidierung erfolgt lokal mithilfe der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

**Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?**

Nein. Die Lizenz ist unbefristet: Sie können weiterhin Versionen verwenden, die vor Ihrem Abonnementende veröffentlicht wurden; Sie können jedoch neuere Releases nur nach einer Verlängerung nutzen.