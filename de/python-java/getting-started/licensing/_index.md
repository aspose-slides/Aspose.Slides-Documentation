---
title: Lizenzierung
description: "Aspose.Slides für Python über Java bietet verschiedene Plans für den Kauf oder bietet eine kostenlose Testversion und eine 30-tägige temporäre Lizenz zur Bewertung unter Verwendung von Lizenzierungs- und Abonnementrichtlinien."
type: docs
weight: 80
url: /de/python-java/licensing/
---

Manchmal kann für die besten Bewertungsergebnisse ein praktischer Ansatz erforderlich sein. Aus diesem Grund bietet Aspose.Slides verschiedene Kaufpläne und bietet auch eine kostenlose Testversion sowie eine 30-tägige temporäre Lizenz zur Bewertung an.

{{% alert color="primary" %}}

Bitte beachten Sie, dass es eine Reihe von allgemeinen Richtlinien und Praktiken gibt, die Ihnen helfen, unsere Produkte korrekt zu bewerten, zu lizenzieren und zu kaufen. Sie finden diese im Abschnitt ["Kaufrichtlinien und FAQ"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Aspose.Slides bewerten**
Sie können Aspose.Slides ganz einfach für die Bewertung herunterladen. Das Evaluierungspaket ist dasselbe wie das gekaufte Paket. Die Evaluierungsversion wird einfach lizenziert, nachdem Sie ein paar Zeilen Code hinzugefügt haben, um die Lizenz anzuwenden.

## **Einschränkungen der Evaluierungsversion**
Die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) bietet die volle Produktfunktionalität, fügt jedoch beim Öffnen und Speichern ein Evaluierungswasserzeichen oben im Dokument ein. Sie sind auch auf eine Folie beschränkt, wenn Sie Texte aus Präsentationsfolien extrahieren.

{{% alert color="primary" %}} 

Wenn Sie Aspose.Slides ohne die Einschränkungen der Evaluierungsversion testen möchten, können Sie eine **30-tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie unter [Wie bekomme ich eine temporäre Lizenz?](https://purchase.aspose.com/temporary-license).

{{% /alert %}} 

## **Über die Lizenz**
Sie können eine Evaluierungsversion von Aspose.Slides für Python über Java ganz einfach von der [Download-Seite](https://releases.aspose.com/slides/python-java/) herunterladen. Die Evaluierungsversion bietet absolut **die gleichen Funktionen** wie die lizenzierte Version von Aspose.Slides. Darüber hinaus wird die Evaluierungsversion einfach lizenziert, nachdem Sie eine Lizenz erworben und ein paar Zeilen Code hinzugefügt haben, um die Lizenz anzuwenden.

Die Lizenz ist eine XML-Datei im Klartext, die Details wie den Produktnamen, die Anzahl der Entwickler, an die sie lizenziert ist, das Ablaufdatum des Abonnements usw. enthält. Die Datei ist digital signiert, daher sollten Sie die Datei nicht ändern. Selbst eine versehentliche Hinzufügung eines zusätzlichen Zeilenumbruchs zum Inhalt der Datei würde sie ungültig machen.

Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie eine Lizenz festlegen, bevor Sie **Aspose.Slides** verwenden. Sie müssen eine Lizenz nur einmal pro Anwendung oder Prozess festlegen.

## Gekaufte Lizenz

Nach dem Kauf müssen Sie die Lizenzdatei oder den Stream anwenden. 

{{% alert color="primary" %}}

Sie müssen die Lizenz festlegen:
* nur einmal pro Anwendungsbereich
* bevor Sie andere Klassen von Aspose.Slides verwenden

{{% /alert %}}

{{% alert color="primary" %}}

Sie finden Preisinformationen auf der Seite [„Preisübersicht“](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

### **Eine Lizenz in Aspose.Slides für Python über Java festlegen**

Lizenzen können von diesen Standorten aus angewendet werden:

* Expliziter Pfad
* Stream
* Als metering Lizenz – ein neues Lizenzierungsmechanismus

{{% alert color="primary" %}}

Verwenden Sie die Methode **setLicense**, um eine Komponente zu lizenzieren.

Während mehrere Aufrufe von **setLicense** nicht schädlich sind, sind sie eine Ressourcenverschwendung (Prozessor).

{{% /alert %}}

#### **Anwenden einer Lizenz mit einer Datei**

Dieser Codeausschnitt wird verwendet, um eine Lizenzdatei festzulegen:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

Beim Aufrufen der Methode setLicense sollte der Lizenzname derselbe sein wie der Ihrer Lizenzdatei. Zum Beispiel können Sie den Lizenzdateinamen in "Aspose.Slides.lic.xml" ändern. Dann müssen Sie in Ihrem Code den neuen Lizenznamen (Aspose.Slides.lic.xml) an die Methode setLicense übergeben.

#### **Anwenden einer Lizenz aus Bytes**

Dieser Codeausschnitt wird verwendet, um eine Lizenz aus Bytes anzuwenden:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### Anwenden einer metering Lizenz

Aspose.Slides ermöglicht Entwicklern, einen metering Schlüssel anzuwenden. Dies ist ein neues Lizenzierungsmechanismus.

Das neue Lizenzierungsmechanismus wird zusammen mit der bestehenden Lizenzierungsmethode verwendet. Kunden, die auf Grundlage der Nutzung von API-Funktionen abgerechnet werden möchten, können die Metered Licensing nutzen.

Nachdem Sie alle erforderlichen Schritte zur Erlangung dieses Lizenztyps abgeschlossen haben, erhalten Sie die Schlüssel, nicht die Lizenzdatei. Dieser metering Schlüssel kann mithilfe der speziell für diesen Zweck eingeführten **Metered**-Klasse angewendet werden.

Das folgende Codebeispiel zeigt, wie metered öffentliche und private Schlüssel festgelegt werden:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# Erstellen Sie eine Instanz der CAD Metered-Klasse
metered = Metered();

# Greifen Sie auf die set_metered_key-Eigenschaft zu und übergeben Sie öffentliche und private Schlüssel als Parameter
metered.setMeteredKey("*****", "*****");

# Holen Sie sich die metering Datenmenge, bevor Sie die API aufrufen
amountbefore = Metered.getConsumptionQuantity()

# Informationen anzeigen
print("Amount Consumed Before: \" + amountbefore + \"" )

# Dokument von der Festplatte laden.
pres = Presentation();

# Zählen Sie die Seiten des Dokuments
print("Amount Consumed After: \" +  pres.getSlides().size()) + \"" )

# als PDF speichern
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# Holen Sie sich die metering Datenmenge nach dem Aufrufen der API
amountafter = Metered.getConsumptionQuantity()

# Informationen anzeigen
print("Amount Consumed After: \" + amountafter + \"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}

Bitte beachten Sie, dass Sie eine stabile Internetverbindung benötigen, um die Metered Lizenz korrekt zu verwenden, da der Metered Mechanismus eine ständige Interaktion mit unseren Diensten für genaue Berechnungen erfordert. Für weitere Details siehe den Abschnitt [„Metered Licensing FAQ“](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}