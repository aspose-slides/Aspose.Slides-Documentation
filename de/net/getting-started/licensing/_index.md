---
title: Lizenzierung
type: docs
weight: 80
url: /de/net/licensing/
---

## **Bewerten Sie Aspose.Slides**

{{% alert color="primary" %}} 

Sie können eine Evaluierungsversion von **Aspose.Slides for NET** von [ihrer NuGet-Downloadseite](https://www.nuget.org/packages/Aspose.Slides.NET/) herunterladen. Die Evaluierungsversion bietet dieselben Funktionalitäten wie die lizenzierte Version des Produkts. Das Evaluierungspaket ist dasselbe wie das gekaufte Paket. Die Evaluierungsversion wird einfach lizenziert, nachdem Sie ein paar Codezeilen hinzugefügt haben (um die Lizenz anzuwenden).

Sobald Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie [eine Lizenz erwerben](https://purchase.aspose.com/buy). Wir empfehlen Ihnen, die verschiedenen Abonnementtypen zu prüfen. Bei Fragen kontaktieren Sie das Aspose-Verkaufsteam.

Jede Aspose-Lizenz enthält ein einjähriges Abonnement für kostenlose Upgrades auf neue Versionen oder Fehlerbehebungen, die während des Abonnementzeitraums veröffentlicht werden. Benutzer mit lizenzierten Produkten oder sogar Evaluierungsversionen erhalten kostenlosen und uneingeschränkten technischen Support.

{{% /alert %}} 

**Einschränkungen der Evaluierungsversion**

* Während die Aspose.Slides-Evaluierungsversion (ohne angegebene Lizenz) die volle Produktfunktionalität bereitstellt, fügt sie bei Öffnungs‑ und Speicheroperationen ein Evaluierungswasserzeichen oben im Dokument ein. 
* Sie sind auf eine Folie beschränkt, wenn Sie Texte aus Präsentationsfolien extrahieren.

{{% alert color="primary" %}} 

Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑Tage‑temporäre Lizenz** anfordern. Siehe die Seite [How to get a Temporary License](https://purchase.aspose.com/temporary-license) für weitere Informationen.

{{% /alert %}}

## **Lizenzierung in Aspose.Slides**
* Eine Evaluierungsversion wird lizenziert, nachdem Sie eine Lizenz erworben und ein paar Codezeilen hinzugefügt haben (um die Lizenz anzuwenden).
* Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie Produktname, Anzahl der lizenzierten Entwickler, Ablaufdatum des Abonnements usw. enthält. 
* Die Lizenzdatei ist digital signiert, sodass Sie die Datei nicht ändern dürfen. Selbst ein unbeabsichtigtes Hinzufügen einer zusätzlichen Zeilenumbruchszeichenkette zum Inhalt der Datei macht sie ungültig.
* Aspose.Slides for .NET versucht typischerweise, die Lizenz an folgenden Orten zu finden:
  * Ein expliziter Pfad
  * Der Ordner, der die DLL der Komponente enthält (in Aspose.Slides enthalten)
  * Der Ordner, der die Assembly enthält, die die DLL der Komponente aufgerufen hat (in Aspose.Slides enthalten)
  * Der Ordner, der die Einstieg‑Assembly enthält (Ihre .exe)
  * Eine eingebettete Ressource in der Assembly, die die DLL der Komponente aufgerufen hat (in Aspose.Slides enthalten).
* Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie vor der Verwendung von Aspose.Slides eine Lizenz festlegen. Sie müssen die Lizenz nur einmal pro Anwendung oder Prozess festlegen.

{{% alert color="primary" %}} 

Sie möchten vielleicht [Metered Licensing](https://docs.aspose.com/slides/net/metered-licensing/) sehen.

{{% /alert %}} 


## **Anwenden einer Lizenz**
Eine Lizenz kann aus einer **Datei**, einem **Stream** oder einer **eingebetteten Ressource** geladen werden. 

{{% alert color="primary" %}}

Aspose.Slides stellt die [License](https://reference.aspose.com/slides/net/aspose.slides/license)-Klasse für Lizenzvorgänge bereit.

{{% /alert %}} 

{{% alert color="warning" %}} 

Neue Lizenzen können Aspose.Slides nur mit Version 21.4 oder neuer aktivieren. Ältere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.

{{% /alert %}}

### **Datei**
Die einfachste Methode, eine Lizenz zu setzen, erfordert, dass Sie die Lizenzdatei im selben Ordner wie die DLL der Komponente (in Aspose.Slides enthalten) ablegen und nur den Dateinamen ohne Pfad angeben.

Dieser C#‑Code zeigt, wie Sie eine Lizenzdatei setzen:
``` csharp
// Instanziiert die Lizenzklasse 
Aspose.Slides.License license = new Aspose.Slides.License();

// Setzt den Pfad zur Lizenzdatei
license.SetLicense("Aspose.Slides.lic");
```


{{% alert color="warning" %}} 

Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf der [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1)-Methode der Lizenzdateiname am Ende des angegebenen expliziten Pfads mit dem Namen Ihrer Lizenzdatei übereinstimmen.

Beispielsweise können Sie den Lizenzdateinamen in *Aspose.Slides.lic.xml* ändern. Dann müssen Sie in Ihrem Code den Pfad zur Datei (enden mit *Aspose.Slides.lic.xml*) an die [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1)-Methode übergeben.

{{% /alert %}}

### **Stream**
Sie können eine Lizenz aus einem Stream laden. Dieser C#‑Code zeigt, wie Sie eine Lizenz aus einem Stream anwenden:
``` csharp
// Instanziiert die Lizenzklasse 
Aspose.Slides.License license = new Aspose.Slides.License();

// Setzt die Lizenz über einen Stream
license.SetLicense(myStream);
```


### **Eingebettete Ressource**
Sie können die Lizenz mit Ihrer Anwendung paketieren (um einen Verlust zu vermeiden), indem Sie die Lizenz als eingebettete Ressource in eine der Assemblies einbinden, die die DLL der Komponente aufrufen (in Aspose.Slides enthalten). 

So fügen Sie eine Lizenzdatei als eingebettete Ressource hinzu:

1. In Visual Studio fügen Sie die Lizenzdatei (.lic) dem Projekt wie folgt hinzu: Gehen Sie zu **File** > **Add Existing Item** > **Add**. 
2. Wählen Sie die Datei im **Solution Explorer** aus.
3. Im **Properties**‑Fenster setzen Sie **Build Action** auf **Embedded Resource**.
4. Um auf die in der Assembly eingebettete Lizenz zuzugreifen, fügen Sie die Lizenzdatei als eingebettete Ressource zum Projekt hinzu und übergeben Sie dann den Lizenzdateinamen an die `SetLicense`‑Methode. 


Die `License`‑Klasse findet die Lizenzdatei automatisch in den eingebetteten Ressourcen. Sie müssen nicht die Methoden `GetExecutingAssembly` und `GetManifestResourceStream` der Klasse `System.Reflection.Assembly` im Microsoft .NET Framework aufrufen.

Dieser C#‑Code zeigt, wie Sie eine Lizenz als eingebettete Ressource setzen:
``` csharp
// Instanziert die Lizenzklasse
Aspose.Slides.License license = new Aspose.Slides.License();

// Gibt den in der Assembly eingebetteten Lizenzdateinamen weiter
license.SetLicense("Aspose.Slides.lic");
```


## **Validieren einer Lizenz**

Um zu prüfen, ob eine Lizenz korrekt gesetzt wurde, können Sie sie validieren. Dieser C#‑Code zeigt, wie Sie eine Lizenz validieren:
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

{{% alert title="Hinweis" color="warning" %}} 

Die Methode [license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/) ist nicht thread‑sicher. Wenn diese Methode gleichzeitig von vielen Threads aufgerufen werden muss, sollten Sie Synchronisationsprimitiven (wie einem Lock) verwenden, um Probleme zu vermeiden. 

{{% /alert %}}

## **FAQ**

**Kann ich die Lizenz in einer komplett offline‑Umgebung (kein Internetzugang) anwenden?**

Ja. Die Lizenzvalidierung erfolgt lokal mithilfe der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

**Was passiert, wenn das ein‑jährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?**

Nein. Die Lizenz ist unbefristet: Sie können weiterhin Versionen nutzen, die vor Ihrem Abonnementende veröffentlicht wurden; Sie können jedoch neuere Releases nicht ohne Erneuerung verwenden.