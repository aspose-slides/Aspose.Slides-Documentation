---
title: Schreibschutz für Präsentationen unter Android
linktitle: Schreibschutz
type: docs
weight: 25
url: /de/androidjava/write-protected-presentation/
keywords:
- Schreibschutz
- PowerPoint-Schreibschutz
- Passwort zum Ändern
- Bearbeitung der Präsentation einschränken
- Schreibschutz entfernen
- Passwort für Änderungen prüfen
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Festlegen, Erkennen, Validieren und Entfernen von Schreibschutz-Passwörtern in PowerPoint PPT- und PPTX-Präsentationen mithilfe von Aspose.Slides für Android über Java."
---
## **Einleitung**

Ein Schreibschutz‑Passwort beschränkt die Änderung einer Präsentation, verschlüsselt jedoch nicht deren Inhalt. Benutzer können eine schreibgeschützte Präsentation ohne das Passwort laden und anzeigen. Je nach Anwendung können sie den Inhalt außerdem bearbeiten und unter einem anderen Namen speichern, sodass Schreibschutz nicht als Vertraulichkeitsmechanismus angesehen werden sollte.

Ein Öffnungs‑Passwort hat einen anderen Zweck: Es verschlüsselt die Präsentation und ist zum Laden ihres Inhalts erforderlich. Um eine Präsentation zu verschlüsseln oder ein Öffnungs‑Passwort zu prüfen, siehe [Passwortgeschützte Präsentationen](/slides/de/androidjava/password-protected-presentation/).

Die Workflows in diesem Artikel gelten sowohl für PPT- als auch für PPTX‑Präsentationen. Die Beispiele verwenden PPTX‑Dateien; beim Speichern als PPT verwenden Sie die Erweiterung `.ppt` und das entsprechende PPT‑Speicherformat.

## **Schreibschutz für eine Präsentation festlegen**

Verwenden Sie [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-), um ein Passwort für die Veränderung einer Präsentation festzulegen. Das Speichern der Präsentation bewahrt die Schutzeinstellung.

Das folgende Beispiel legt Schreibschutz für eine PPTX‑Präsentation fest:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Schreibgeschützte Präsentation laden**

Da Schreibschutz den Präsentationsinhalt nicht verschlüsselt, ist zum Laden der Präsentation kein Passwort erforderlich. Das Passwort ist nur relevant, wenn die Berechtigung zum Ändern der geschützten Präsentation geprüft wird.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Übergeben Sie kein Schreibschutz‑Passwort an [ILoadOptions.setPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Diese Methode akzeptiert ein Öffnungs‑Passwort für verschlüsselten Inhalt. Hat eine Präsentation beide Schutzarten, geben Sie das Öffnungs‑Passwort zum Laden an und behandeln das Schreibschutz‑Passwort separat.

## **Schreibschutz von einer Präsentation entfernen**

Verwenden Sie [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) , um die Änderungsbeschränkung zu entfernen, und speichern Sie anschließend die Präsentation.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Um eine Datei zu prüfen, ohne eine vollständige [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Instanz zu erstellen, rufen Sie [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) auf und prüfen Sie [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Die Methode verwendet [NullableBool](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/nullablebool/) und gibt `NullableBool.True` zurück, wenn Schreibschutz festgestellt wird.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

Die Stream‑Überladung von [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) liefert dieselben Informationen für eine als Stream bereitgestellte Präsentation.

## **Schreibschutz‑Passwort validieren**

Verwenden Sie [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-), um ein Änderungs‑Passwort zu validieren, ohne die komplette Präsentation zu laden. Prüfen Sie zuerst [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--), damit die Anwendung ein Passwort nur anfordert oder prüft, wenn Schreibschutz vorhanden ist.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) validiert nur das Schreibschutz‑Passwort. Es prüft kein Öffnungs‑Passwort und bestimmt nicht, ob verschlüsselter Inhalt geladen werden kann. Im Gegenzug validiert [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) ausschließlich ein Öffnungs‑Passwort. Wenn bereits eine vollständige Präsentation geladen wurde, bietet [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) die gleichwertige Schreibschutz‑Prüfung über den Schutz‑Manager.

In Produktionsanwendungen sollten Passwörter nicht geloggt oder in Diagnose‑Nachrichten eingebettet werden. Vermeiden Sie unnötige wiederholte Validierungsversuche und halten Sie Passwörter im Speicher nur so lange wie nötig.

{{% alert color="info" title="Siehe auch" %}}
- [Passwortgeschützte Präsentationen](/slides/de/androidjava/password-protected-presentation/)
- [Nur-Lese‑Präsentationen](/slides/de/androidjava/read-only-presentation/)
- [Digitale Signatur in PowerPoint](/slides/de/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Verschlüsselt Schreibschutz eine Präsentation?**

Nein. Er beschränkt die Änderungen, lässt jedoch den Präsentationsinhalt zum Laden und Anzeigen verfügbar.

**Ist das Schreibschutz‑Passwort zum Öffnen einer Präsentation erforderlich?**

Nein. Nur ein Öffnungs‑Passwort ist zum Laden verschlüsselter Präsentationsinhalte erforderlich.

**Kann eine Präsentation sowohl ein Öffnungs‑Passwort als auch ein Schreibschutz‑Passwort haben?**

Ja. Das Öffnungs‑Passwort wird über die Ladeoptionen übergeben, um die verschlüsselte Präsentation zu öffnen, und das Schreibschutz‑Passwort wird separat validiert, wenn eine Änderungs‑Autorisation benötigt wird.