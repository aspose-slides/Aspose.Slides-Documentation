---
title: Lizenzierung
type: docs
weight: 120
url: /de/cpp/licensing/
---

## **Evaluieren von Aspose.Slides**

{{% alert color="primary" %}} 

Sie können eine Evaluierungsversion von **Aspose.Slides for C++** von [seiner NuGet-Download-Seite](https://www.nuget.org/packages/Aspose.Slides.CPP/) herunterladen. Die Evaluierungsversion bietet die gleichen Funktionalitäten wie die lizenzierte Version des Produkts. Das Evaluierungspaket ist dasselbe wie das gekaufte Paket. Die Evaluierungsversion wird einfach lizenziert, nachdem Sie einige Zeilen Code hinzugefügt haben, um die Lizenz anzuwenden.

Sobald Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie [eine Lizenz erwerben](https://purchase.aspose.com/buy). Wir empfehlen Ihnen, die verschiedenen Abonnementtypen durchzugehen. Wenn Sie Fragen haben, kontaktieren Sie das Aspose-Vertriebsteam.

Jede Aspose-Lizenz enthält einjährige Abonnements für kostenlose Upgrades auf neue Versionen oder Fehlerbehebungen, die innerhalb des Abonnementzeitraums veröffentlicht werden. Benutzer mit lizenzierten Produkten oder sogar Evaluierungsversionen erhalten kostenlose und unbegrenzte technische Unterstützung.

{{% /alert %}} 

**Einschränkungen der Evaluierungsversion**

* Während die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) die volle Produktfunktionalität bietet, fügt sie beim Öffnen und Speichern des Dokuments ein Evaluierungswasserzeichen oben im Dokument ein. 
* Sie sind auf eine Folie beschränkt, wenn Sie Texte aus Präsentationsfolien extrahieren.

{{% alert color="primary" %}} 

Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30-Tage-Testlizenz** anfordern. Weitere Informationen finden Sie auf der Seite [Wie man eine Testlizenz erhält](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Lizenzierung in Aspose.Slides**

* Eine Evaluierungsversion wird lizenziert, nachdem Sie eine Lizenz erworben und ein paar Zeilen Code hinzugefügt haben (um die Lizenz anzuwenden).
* Die Lizenz ist eine Klartext-XML-Datei, die Details wie den Produktnamen, die Anzahl der Entwickler, für die sie lizenziert ist, das Ablaufdatum des Abonnements und so weiter enthält. 
* Die Lizenzdatei ist digital signiert, daher dürfen Sie die Datei nicht modifizieren. Selbst eine unbeabsichtigte Hinzufügung eines zusätzlichen Zeilenumbruchs zum Inhalt der Datei macht sie ungültig.
* Aspose.Slides für C++ versucht normalerweise, die Lizenz an diesen Orten zu finden:
  * Ein expliziter Pfad
  * Der Ordner, der die DLL der Komponente enthält (in Aspose.Slides enthalten)
  * Der Ordner, der die Assembly enthält, die die DLL der Komponente aufruft (in Aspose.Slides enthalten)
* Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie eine Lizenz festlegen, bevor Sie Aspose.Slides verwenden. Sie müssen die Lizenz nur einmal pro Anwendung oder Prozess festlegen.

## **Anwenden einer Lizenz**

Eine Lizenz kann aus einer **Datei**, einem **Stream** oder einem **eingebetteten Ressource** geladen werden. 

{{% alert color="primary" %}}

Aspose.Slides bietet die [License](https://reference.aspose.com/slides/cpp/class/aspose.slides.license/) Klasse für Lizenzierungsoperationen.

{{% /alert %}} 

### **Datei**

Die einfachste Methode zum Festlegen einer Lizenz erfordert, dass Sie die Lizenzdatei im gleichen Ordner platzieren, der die DLL der Komponente enthält (in Aspose.Slides enthalten), und den Dateinamen ohne den Pfad angeben.

Dieser C++-Code zeigt Ihnen, wie Sie eine Lizenzdatei festlegen:

```c++
SharedPtr<Aspose::Slides::License> lic = MakeObject<Aspose::Slides::License>();

lic->SetLicense(L"Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Wenn Sie die Lizenzdatei in ein anderes Verzeichnis legen, muss der Lizenzdateiname am Ende des angegebenen Pfads der Lizenzdatei entsprechen, wenn Sie die [License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67) Methode aufrufen.

Zum Beispiel können Sie den Lizenzdateinamen in *Aspose.Slides.lic.xml* ändern. Dann müssen Sie in Ihrem Code den Pfad zur Datei (der mit *Aspose.Slides.lic.xml* endet) an die [License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67) Methode übergeben.

{{% /alert %}}

### **Stream**

Sie können eine Lizenz aus einem Stream laden. Dieser C++-Code zeigt Ihnen, wie Sie eine Lizenz aus einem Stream anwenden:

```c++
SharedPtr<Aspose::Slides::License> lic = MakeObject<Aspose::Slides::License>();

System::SharedPtr<System::IO::FileStream> stream= System::IO::File::OpenRead(L"Aspose.Slides.lic");

lic->SetLicense(stream); 
```

## **Validierung einer Lizenz**

Um zu überprüfen, ob eine Lizenz ordnungsgemäß festgelegt wurde, können Sie sie validieren. Dieser C++-Code zeigt Ihnen, wie Sie eine Lizenz validieren:

```c++
System::SharedPtr<Aspose::Slides::License> license = System::MakeObject<Aspose::Slides::License>();
license->SetLicense(u"Aspose.Slides.lic");
if (license->IsLicensed())
{
    System::Console::WriteLine(u"Lizenz ist gültig!");
    System::Console::Read();
}
```

## **Thread-Sicherheit**

{{% alert title="Hinweis" color="warning" %}} 

Die [License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67) Methode ist nicht thread-sicher. Wenn diese Methode gleichzeitig von vielen Threads aufgerufen werden muss, sollten Sie Synchronisationsprimitive (wie ein Lock) verwenden, um Probleme zu vermeiden. 

{{% /alert %}}