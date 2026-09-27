---
title: Lizenzierung
type: docs
weight: 90
url: /de/androidjava/licensing/
keywords:
- Lizenz
- Temporäre Lizenz
- Lizenz setzen
- Lizenz verwenden
- Lizenz validieren
- Lizenzdatei
- Evaluierungsversion
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Lizenzen in Aspose.Slides für Android via Java anwenden, verwalten und Probleme beheben. Stellen Sie mit unserem Lizenzierungsleitfaden einen ununterbrochenen Zugriff auf alle Funktionen sicher."
---
## **Übersicht**

Aspose.Slides kann im Evaluierungsmodus oder mit einer gültigen Lizenz verwendet werden. Die Evaluierungsversion bietet die gleiche Funktionalität wie die lizenzierte Version, fügt jedoch jedem Folien einer gespeicherten Präsentation ein Evaluierungswasserzeichen hinzu und kürzt den Text, den Ihr Code aus Präsentationen liest.

Dieser Artikel erklärt, wie die Lizenzierung in Aspose.Slides funktioniert und wie Sie vor der Verwendung der Bibliothek eine Lizenz anwenden. Eine Lizenz kann aus einer Datei, einem Stream oder einer eingebetteten Ressource geladen werden, indem die [License](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/license/)‑Klasse verwendet wird. Der Artikel zeigt außerdem, wie Sie prüfen können, ob eine Lizenz korrekt angewendet wurde.

## **Aspose.Slides evaluieren**

{{% alert color="info" title="Hinweis" %}}

Sie können eine Evaluierungsversion von **Aspose.Slides for Android via Java** von der jeweiligen [download page](https://releases.aspose.com/slides/de/androidjava/) herunterladen. Die Evaluierungsversion bietet dieselben Funktionalitäten wie die lizenzierte Version des Produkts. Das Evaluierungspaket ist identisch mit dem gekauften Paket. Die Evaluierungsversion wird einfach lizenziert, nachdem Sie ein paar Codezeilen hinzugefügt haben (um die Lizenz anzuwenden).

Sobald Sie mit Ihrer Evaluierung von **Aspose.Slides** zufrieden sind, können Sie eine [purchase a license](https://purchase.aspose.com/pricing/slides/de/android-java/) erwerben. Wir empfehlen Ihnen, die verschiedenen Abonnementtypen zu prüfen. Bei Fragen kontaktieren Sie das Aspose‑Vertriebsteam.

Jede Aspose‑Lizenz beinhaltet ein einjähriges Abonnement für kostenlose Upgrades auf neue Versionen oder Fehlerbehebungen, die innerhalb des Abonnementzeitraums veröffentlicht werden. Benutzer mit lizenzierten Produkten (oder sogar Evaluierungsversionen) erhalten kostenlosen und unbegrenzten technischen Support.

{{% /alert %}} 

**Einschränkungen der Evaluierungsversion**

* Die Evaluierungsversion (ohne angegebene Lizenz) bietet die vollständige Produktfunktionalität, fügt jedoch jedem Folien einer gespeicherten Präsentation ein Evaluierungswasserzeichen‑Textfeld hinzu.
* Text, den Ihr Code aus einer Präsentation liest, wird auf die ersten Zeichen gekürzt, gefolgt von einem Hinweis auf die Evaluierungseinschränkung. Text, den Ihr Code schreibt, wird vollständig gespeichert.

{{% alert color="info" title="Hinweis" %}}

Um Aspose.Slides ohne Einschränkungen zu testen, können Sie eine **30‑Tage‑Temporär‑Lizenz** anfordern. Siehe die Seite [How to get a Temporary License](https://purchase.aspose.com/temporary-license) für weitere Informationen.

{{% /alert %}}

## **Lizenzierung in Aspose.Slides**

* Eine Evaluierungsversion wird nach dem Kauf einer Lizenz und dem Hinzufügen einiger Codezeilen lizenziert (um die Lizenz anzuwenden).
* Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie den Produktnamen, die Anzahl der lizenzierten Entwickler, das Ablaufdatum des Abonnements usw. enthält. 
* Die Lizenzdatei ist digital signiert, daher dürfen Sie die Datei nicht verändern. Selbst das versehentliche Hinzufügen eines zusätzlichen Zeilenumbruchs zum Inhalt der Datei macht sie ungültig.
* Aspose.Slides for Android via Java versucht typischerweise, die Lizenz an folgenden Orten zu finden:
  * Ein expliziter Pfad
  * Der Ordner, der Aspose.Slides.jar enthält
* Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie vor der Verwendung von **Aspose.Slides** eine Lizenz setzen. Sie müssen die Lizenz nur einmal pro Anwendung oder Prozess setzen.

## **Anwenden einer Lizenz**

Eine Lizenz kann aus einer **Datei** oder einem **Stream** geladen werden.

{{% alert color="info" title="Hinweis" %}}

Aspose.Slides stellt die [License](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/license/)‑Klasse für Lizenzvorgänge bereit.

{{% /alert %}} 

{{% alert color="warning" title="Warnung" %}}

Neue Lizenzen können Aspose.Slides nur ab Version 21.4 aktivieren. Ältere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.

{{% /alert %}}

### **Datei**

Die einfachste Methode, eine Lizenz zu setzen, besteht darin, die Lizenzdatei in den Ordner zu legen, der Aspose.Slides.jar oder das JAR Ihrer Anwendung enthält.

{{% alert color="info" title="Hinweis" %}}

Unter Android werden die Bibliothek und Ihre App in das APK gepackt, sodass es keinen Ordner gibt, der die JAR‑Datei der Bibliothek enthält, und ein relativer Pfad wie *Aspose.Slides.Android.via.Java.lic* nicht auf eine Datei in Ihrer App verweist. Fügen Sie die Lizenzdatei zu den Assets Ihrer App hinzu und laden Sie sie aus einem Stream, wie in [Stream from App Assets](#stream-from-app-assets) gezeigt.

{{% /alert %}}

Dieser Java‑Code zeigt, wie Sie eine Lizenzdatei setzen:

``` java
// Instanziert die Lizenzklasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Setzt den Lizenzdateipfad
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warnung" %}}

Wenn Sie die Lizenzdatei in einem anderen Verzeichnis ablegen, muss beim Aufruf der [setLicense](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)‑Methode der Lizenzdateiname am Ende des angegebenen Pfads exakt dem Namen Ihrer Lizenzdatei entsprechen.

Beispielsweise können Sie den Lizenzdateinamen in *Aspose.Slides.Android.via.Java.lic.xml* ändern. Dann müssen Sie in Ihrem Code den Pfad zur Datei (endend mit *Aspose.Slides.Android.via.Java.lic.xml*) an die [setLicense](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)‑Methode übergeben.

{{% /alert %}}

### **Stream**

Sie können eine Lizenz aus einem Stream laden. Dieser Java‑Code zeigt, wie Sie eine Lizenz aus einem Stream anwenden:

``` java
// Instanziert die Lizenzklasse
com.aspose.slides.License license = new com.aspose.slides.License();

// Setzt die Lizenz über einen Stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **Stream aus App Assets**

In einer Android‑App legen Sie die Lizenzdatei in den *assets*‑Ordner des App‑Moduls, *app/src/main/assets*, damit sie in das APK gepackt wird. Öffnen Sie die Datei mit der [getAssets](https://developer.android.com/reference/android/content/Context#getAssets())‑Methode und übergeben Sie den Stream an die [setLicense](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-)‑Methode. Der Code läuft innerhalb einer `Activity`, zum Beispiel in ihrer `onCreate`‑Methode, bevor die App Aspose.Slides verwendet:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

Der an die [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String))‑Methode übergebene Dateiname ist relativ zum *assets*‑Ordner. Wenn die Datei dort nicht existiert, protokolliert der Code den Fehler und Aspose.Slides bleibt im Evaluierungsmodus. Um zu prüfen, ob die Lizenz angewendet wurde, siehe [Validieren einer Lizenz](#validating-a-license).

## **Validieren einer Lizenz**

Um zu prüfen, ob eine Lizenz korrekt gesetzt wurde, können Sie sie validieren. Dieser Java‑Code zeigt, wie Sie eine Lizenz validieren:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Thread‑Sicherheit**

{{% alert color="warning" title="Warnung" %}}

Die [setLicense](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-)‑Methode ist nicht threadsicher. Wenn diese Methode gleichzeitig von vielen Threads aufgerufen werden muss, sollten Sie Synchronisations‑Primitiven (wie ein Lock) verwenden, um Probleme zu vermeiden.

{{% /alert %}}

## **FAQ**

### Kann ich die Lizenz in einer komplett offline Umgebung (keine Internetverbindung) anwenden?

Ja. Die Lizenzvalidierung erfolgt lokal mithilfe der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

### Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?

Nein. Die Lizenz ist unbefristet: Sie können weiterhin Versionen verwenden, die vor Ihrem Abonnementende veröffentlicht wurden; Sie können jedoch ohne Verlängerung keine neueren Releases nutzen.