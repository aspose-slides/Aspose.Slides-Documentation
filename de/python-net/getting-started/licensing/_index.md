---
title: Lizenzierung
type: docs
weight: 80
url: /de/python-net/licensing/
keywords:
- Lizenz
- temporäre Lizenz
- Lizenz festlegen
- Lizenz verwenden
- Lizenz validieren
- Lizenzdatei
- Evaluierungsversion
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Lizenzen in Aspose.Slides for Python via .NET anwenden, verwalten und Fehler beheben. Stellen Sie mit unserer Schritt‑für‑Schritt‑Lizenzierungsanleitung einen unterbrechungsfreien Zugriff auf alle Funktionen sicher."
---

## **Bewertung von Aspose.Slides**

{{% alert color="primary" %}} 

Sie können eine Evaluierungsversion von **Aspose.Slides für Python über .NET** von der [Download-Seite](https://pypi.org/project/Aspose.Slides/) herunterladen. Die Evaluierungsversion bietet dieselben Funktionen wie die lizenzierte Version des Produkts. Das Evaluierungspaket ist das gleiche wie das gekaufte Paket. Die Evaluierungsversion wird einfach lizenziert, nachdem Sie einige Codezeilen hinzugefügt haben (um die Lizenz anzuwenden).

Sobald Sie mit Ihrer Bewertung von **Aspose.Slides** zufrieden sind, können Sie eine [Lizenz kaufen](https://purchase.aspose.com/buy). Wir empfehlen Ihnen, die verschiedenen Abonnementtypen durchzugehen. Bei Fragen kontaktieren Sie bitte das Vertriebsteam von Aspose.

Jede Aspose-Lizenz beinhaltet ein einjähriges Abonnement für kostenlose Upgrades auf neue Versionen oder Fixes, die innerhalb des Abonnementszeitraums veröffentlicht werden. Benutzer mit lizenzierten Produkten oder sogar Evaluierungsversionen erhalten kostenlosen und unbegrenzten technischen Support.

{{% /alert %}} 

**Einschränkungen der Evaluierungsversion**

* Während die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) die volle Produktfunktionalität bietet, wird ein Evaluierungswasserzeichen oben im Dokument bei Öffnungs- und Speicheroperationen eingefügt. 
* Sie sind auf eine Folie beschränkt, wenn Sie Texte aus Präsentationsfolien extrahieren.

{{% alert color="primary" %}} 

Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30-tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie auf der Seite [Wie man eine temporäre Lizenz erhält](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Lizenzierung in Aspose.Slides**

* Eine Evaluierungsversion wird lizenziert, nachdem Sie eine Lizenz gekauft und einige Codezeilen hinzugefügt haben (um die Lizenz anzuwenden).
* Die Lizenz ist eine Klartext-XML-Datei, die Details wie den Produktnamen, die Anzahl der entwickelten, für die sie lizenziert ist, das Ablaufdatum des Abonnements usw. enthält. 
* Die Lizenzdatei ist digital signiert, daher dürfen Sie die Datei nicht ändern. Selbst das versehentliche Hinzufügen eines zusätzlichen Zeilenumbruchs zum Inhalt der Datei macht sie ungültig.
* Aspose.Slides für Python über .NET versucht typischerweise, die Lizenz an diesen Standorten zu finden:
  * Ein expliziter Pfad
  * Der Ordner, der das Python-Skript enthält, das Aspose.Slides für Python über .NET aufruft
* Um die Einschränkungen der Evaluierungsversion zu vermeiden, müssen Sie eine Lizenz festlegen, bevor Sie Aspose.Slides verwenden. Sie müssen eine Lizenz nur einmal pro Anwendung oder Prozess festlegen.

{{% alert color="primary" %}} 

Sie sollten sich [Metered Licensing](/slides/de/python-net/metered-licensing/) ansehen.

{{% /alert %}} 


## **Anwenden einer Lizenz**

Eine Lizenz kann aus einer **Datei**, **Strom** oder **eingebetteten Ressource** geladen werden. 

{{% alert color="primary" %}}

Aspose.Slides bietet die [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) Klasse für Lizenzierungsoperationen.

{{% /alert %}} 

### **Datei**

Die einfachste Methode zum Festlegen einer Lizenz erfordert, dass Sie die Lizenzdatei im selben Ordner platzieren, der die DLL des Components (in Aspose.Slides enthalten) enthält, und den Dateinamen ohne den Pfad angeben.

Dieser Python-Code zeigt Ihnen, wie Sie eine Lizenzdatei festlegen:

``` python
import aspose.slides as slides

# Instanziiert die License-Klasse 
license = slides.License()

# Legt den Lizenzdateipfad fest
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}} 

Wenn Sie die Lizenzdatei in ein anderes Verzeichnis legen, muss beim Aufruf der [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/) Methode der Lizenzdateiname am Ende des angegebenen Expliziten der gleiche wie Ihre Lizenzdatei sein.

Zum Beispiel können Sie den Lizenzdateinamen auf *Aspose.Slides.lic.xml* ändern. Dann müssen Sie in Ihrem Code den Pfad zur Datei (der mit *Aspose.Slides.lic.xml* endet) an die [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/) Methode übergeben.

{{% /alert %}}

### **Strom**

Sie können eine Lizenz aus einem Strom laden. Dieser Python-Code zeigt Ihnen, wie Sie eine Lizenz aus einem Strom anwenden:

``` python
import aspose.slides as slides

# Instanziiert die License-Klasse 
license = slides.License()

#Legt die Lizenz über einen Strom fest
license.set_license(stream)
```

## **Überprüfung einer Lizenz**

Um zu überprüfen, ob eine Lizenz richtig festgelegt wurde, können Sie sie validieren. Dieser Python-Code zeigt Ihnen, wie Sie eine Lizenz validieren:

```python
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("Lizenz ist gültig!")
```

## **Thread-Sicherheit**

{{% alert title="Hinweis" color="warning" %}} 

Die [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/) Methode ist nicht thread-sicher. Wenn diese Methode gleichzeitig von vielen Threads aufgerufen werden muss, sollten Sie Synchronisationsprimitive (wie einen Lock) verwenden, um Probleme zu vermeiden. 

{{% /alert %}}