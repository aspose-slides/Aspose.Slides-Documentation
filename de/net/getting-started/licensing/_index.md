---
title: Lizenzierung
type: docs
weight: 80
url: /net/licensing/
---

## **Bewerten von Aspose.Slides**

{{% alert color="primary" %}} 

Sie können eine Evaluierungsversion von **Aspose.Slides für .NET** von [seiner NuGet-Download-Seite](https://www.nuget.org/packages/Aspose.Slides.NET/) herunterladen. Die Evaluierungsversion bietet die gleichen Funktionalitäten wie die lizenzierte Version des Produkts. Das Evaluierungspaket ist dasselbe wie das gekaufte Paket. Die Evaluierungsversion wird einfach lizenziert, nachdem Sie ein paar Zeilen Code hinzugefügt haben (um die Lizenz anzuwenden).

Sobald Sie mit Ihrer Bewertung von **Aspose.Slides** zufrieden sind, können Sie [eine Lizenz erwerben](https://purchase.aspose.com/buy). Wir empfehlen Ihnen, die verschiedenen Abonnementtypen durchzugehen. Wenn Sie Fragen haben, wenden Sie sich an das Vertriebsteam von Aspose.

Jede Aspose-Lizenz beinhaltet ein einjähriges Abonnement für kostenlose Updates auf neue Versionen oder Bugfixes, die innerhalb des Abonnementzeitraums veröffentlicht werden. Benutzer mit lizenzierten Produkten oder sogar Evaluierungsversionen erhalten kostenlose und unbegrenzte technische Unterstützung.

{{% /alert %}} 

**Einschränkungen der Evaluierungsversion**

* Während die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) die volle Produktfunktionalität bietet, fügt sie beim Öffnen und Speichern des Dokuments ein Evaluierungswasserzeichen oben im Dokument ein.
* Sie sind auf eine Folie beschränkt, wenn Sie Texte aus Präsentationsfolien extrahieren.

{{% alert color="primary" %}} 

Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30-tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie auf der Seite [So erhalten Sie eine temporäre Lizenz](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Lizenzierung in Aspose.Slides**
* Eine Evaluierungsversion wird lizenziert, nachdem Sie eine Lizenz erwerben und ein paar Zeilen Code hinzufügen (um die Lizenz anzuwenden).
* Die Lizenz ist eine XML-Datei im Klartext, die Details wie den Produktnamen, die Anzahl der Entwickler, auf die sie lizenziert ist, das Ablaufdatum des Abonnements usw. enthält.
* Die Lizenzdatei ist digital signiert, daher dürfen Sie die Datei nicht ändern. Selbst das unbeabsichtigte Hinzufügen eines zusätzlichen Zeilenumbruchs zu den Inhalten der Datei macht sie ungültig.
* Aspose.Slides für .NET versucht normalerweise, die Lizenz an diesen Orten zu finden:
  * Ein expliziter Pfad
  * Der Ordner, der die DLL der Komponente enthält (in Aspose.Slides enthalten)
  * Der Ordner, der die Assembly enthält, die die DLL der Komponente aufruft (in Aspose.Slides enthalten)
  * Der Ordner, der die Einstieg-Assembly enthält (Ihr .exe)
  * Eine eingebettete Ressource in der Assembly, die die DLL der Komponente aufruft (in Aspose.Slides enthalten).
* Um die Einschränkungen der Evaluierungsversion zu vermeiden, müssen Sie eine Lizenz festlegen, bevor Sie Aspose.Slides verwenden. Sie müssen nur einmal pro Anwendung oder Prozess eine Lizenz festlegen.

{{% alert color="primary" %}} 

Sie möchten vielleicht [Metered Licensing](https://docs.aspose.com/slides/net/metered-licensing/) sehen.

{{% /alert %}} 

## **Anwenden einer Lizenz**
Eine Lizenz kann aus einer **Datei**, **Stream** oder **eingebetteten Ressource** geladen werden.

{{% alert color="primary" %}}

Aspose.Slides bietet die [License](https://reference.aspose.com/slides/net/aspose.slides/license) Klasse für Lizenzierungsoperationen.

{{% /alert %}} 

### **Datei**
Die einfachste Methode zum Festlegen einer Lizenz erfordert, dass Sie die Lizenzdatei in denselben Ordner platzieren, der die DLL der Komponente enthält (in Aspose.Slides enthalten) und nur den Dateinamen ohne den Pfad angeben.

Dieser C#-Code zeigt Ihnen, wie Sie eine Lizenzdatei festlegen:

``` csharp
// Instanziert die License-Klasse 
Aspose.Slides.License license = new Aspose.Slides.License();

// Setzt den Lizenzdateipfad
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Wenn Sie die Lizenzdatei in ein anderes Verzeichnis legen, muss der Dateiname der Lizenzdatei am Ende des angegebenen expliziten Pfades derselbe sein wie Ihre Lizenzdatei.

Zum Beispiel können Sie den Lizenzdateinamen auf *Aspose.Slides.lic.xml* ändern. Dann müssen Sie in Ihrem Code den Pfad zu der Datei (der mit *Aspose.Slides.lic.xml* endet) an die [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1) Methode übergeben.

{{% /alert %}}

### **Stream**
Sie können eine Lizenz von einem Stream laden. Dieser C#-Code zeigt Ihnen, wie Sie eine Lizenz von einem Stream anwenden:

``` csharp
// Instanziert die License-Klasse 
Aspose.Slides.License license = new Aspose.Slides.License();

// Setzt die Lizenz über einen Stream
license.SetLicense(myStream);
```

### **Eingebettete Ressource**
Sie können die Lizenz mit Ihrer Anwendung paketieren (um zu verhindern, dass sie verloren geht), indem Sie die Lizenz als eingebettete Ressource in eine der Assemblies hinzufügen, die die DLL der Komponente aufruft (in Aspose.Slides enthalten).

So fügen Sie eine Lizenzdatei als eingebettete Ressource hinzu:

1. Fügen Sie in Visual Studio die Lizenzdatei (.lic) so zum Projekt hinzu: Gehen Sie auf **Datei** > **Vorhandenes Element hinzufügen** > **Hinzufügen**.
2. Wählen Sie die Datei im **Projektmappen-Explorer** aus.
3. Stellen Sie im **Eigenschaften**-Fenster die **Build-Aktion** auf **Eingebettete Ressource** ein.
4. Um auf die im Assembly eingebettete Lizenz zuzugreifen, fügen Sie die Lizenzdatei als eingebettete Ressource zum Projekt hinzu und übergeben dann den Dateinamen der Lizenz an die `SetLicense` Methode.

Die `License`-Klasse findet automatisch die Lizenzdatei in den eingebetteten Ressourcen. Sie müssen nicht die Methoden `GetExecutingAssembly` und `GetManifestResourceStream` der `System.Reflection.Assembly`-Klasse im Microsoft .NET Framework aufrufen.

Dieser C#-Code zeigt Ihnen, wie Sie eine Lizenz als eingebettete Ressource festlegen:

``` csharp
// Instanziert die License-Klasse
Aspose.Slides.License license = new Aspose.Slides.License();

// Gibt den in der Assembly eingebetteten Lizenzdateinamen an
license.SetLicense("Aspose.Slides.lic");
```

## **Gültigkeit einer Lizenz überprüfen**

Um zu überprüfen, ob eine Lizenz korrekt festgelegt wurde, können Sie sie validieren. Dieser C#-Code zeigt Ihnen, wie Sie eine Lizenz validieren:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("Lizenz ist gültig!");
    Console.Read();
}
```

## **Thread-Sicherheit**

{{% alert title="Hinweis" color="warning" %}} 

Die Methode [license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/) ist nicht thread-sicher. Wenn diese Methode gleichzeitig von mehreren Threads aufgerufen werden muss, sollten Sie möglicherweise Synchronisationsprimitive (wie einen Lock) verwenden, um Probleme zu vermeiden. 

{{% /alert %}}