---
title: Schreibschutz für Präsentationen in Java
linktitle: Schreibschutz
type: docs
weight: 25
url: /de/java/write-protected-presentation/
keywords:
- Schreibschutz
- PowerPoint-Schreibschutz
- Passwort zum Ändern
- Präsentationsbearbeitung einschränken
- Schreibschutz entfernen
- Änderungs‑Passwort validieren
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Schreibschutz‑Passwörter in PowerPoint‑PPT‑ und PPTX‑Präsentationen setzen, erkennen, validieren und entfernen mit Aspose.Slides für Java."
---
## **Einleitung**

Ein Schreibschutz-Passwort schränkt die Änderung einer Präsentation ein, verschlüsselt jedoch nicht deren Inhalt. Benutzer können eine schreibgeschützte Präsentation ohne Passwort laden und anzeigen. Je nach Anwendung können sie den Inhalt außerdem bearbeiten und unter einem anderen Namen speichern, daher sollte Schreibschutz nicht als Vertraulichkeitsmechanismus betrachtet werden.

Ein Öffnungs­passwort hat einen anderen Zweck: Es verschlüsselt die Präsentation und muss zum Laden des Inhalts angegeben werden. Zum Verschlüsseln einer Präsentation oder zum Validieren eines Öffnungs­passworts siehe [Password-Protect Presentations](/slides/de/java/password-protected-presentation/).

Die in diesem Artikel beschriebenen Arbeitsabläufe gelten sowohl für PPT‑ als auch für PPTX‑Präsentationen. Die Beispiele verwenden PPTX‑Dateien; beim Speichern im PPT‑Format verwenden Sie die Erweiterung `.ppt` und das entsprechende PPT‑Speicherformat.

## **Schreibschutz für eine Präsentation festlegen**

Verwenden Sie [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-), um ein Passwort für die Änderung einer Präsentation zuzuweisen. Das Speichern der Präsentation bewahrt die Schutz‑Einstellung.

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

## **Eine schreibgeschützte Präsentation laden**

Da Schreibschutz den Präsentationsinhalt nicht verschlüsselt, ist kein Passwort zum Laden der Präsentation erforderlich. Das Passwort ist nur relevant, wenn die Berechtigung zum Ändern der geschützten Präsentation geprüft wird.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Übergeben Sie kein Schreibschutz‑Passwort an [ILoadOptions.setPassword](https://reference.aspose.com/slides/de/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Diese Methode akzeptiert ein Öffnungs­passwort für verschlüsselten Inhalt. Wenn eine Präsentation beide Schutzarten besitzt, geben Sie das Öffnungs­passwort zum Laden an und behandeln Sie das Schreibschutz‑Passwort separat.

## **Schreibschutz von einer Präsentation entfernen**

Verwenden Sie [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) zum Entfernen der Änderungsbeschränkung und speichern Sie anschließend die Präsentation.

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

Um eine Datei zu untersuchen, ohne eine vollständige [Presentation]((https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/))‑Instanz zu erstellen, rufen Sie [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) auf und prüfen Sie [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Die Methode verwendet [NullableBool](https://reference.aspose.com/slides/de/java/com.aspose.slides/nullablebool/) und liefert `NullableBool.True`, wenn Schreibschutz erkannt wird.

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

Die Stream‑Überladung von [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) liefert dieselben Informationen für eine als Stream bereitgestellte Präsentation.

## **Validierung eines Schreibschutz‑Passworts**

Verwenden Sie [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-), um ein Änderungs‑Passwort zu prüfen, ohne die gesamte Präsentation zu laden. Prüfen Sie zuerst [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--), damit die Anwendung nur dann ein Passwort anfordert oder validiert, wenn Schreibschutz vorhanden ist.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) prüft ausschließlich das Schreibschutz‑Passwort. Es validiert weder ein Öffnungs­passwort noch bestimmt es, ob verschlüsselter Inhalt geladen werden kann. Im Gegenzug prüft [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) nur ein Öffnungs­passwort. Wenn bereits eine vollständige Präsentation geladen wurde, bietet [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) die äquivalente Schreibschutz‑Prüfung über dessen Schutz‑Manager.

In Produktionsanwendungen sollten Passwörter nicht protokolliert oder in Diagnosemeldungen eingefügt werden. Vermeiden Sie unnötige wiederholte Validierungsversuche und behalten Sie Passwörter im Speicher nur so lange, wie sie benötigt werden.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/de/java/password-protected-presentation/)
- [Read-Only Presentations](/slides/de/java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/de/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Verschlüsselt Schreibschutz eine Präsentation?**

Nein. Er schränkt die Änderung ein, lässt jedoch den Präsentationsinhalt zum Laden und Anzeigen verfügbar.

**Ist das Schreibschutz‑Passwort zum Öffnen einer Präsentation erforderlich?**

Nein. Zum Laden verschlüsselter Präsentationsinhalte ist ausschließlich ein Öffnungs­passwort erforderlich.

**Kann eine Präsentation sowohl ein Öffnungs­passwort als auch ein Schreibschutz‑Passwort haben?**

Ja. Geben Sie das Öffnungs­passwort über die Ladeoptionen an, um die verschlüsselte Präsentation zu öffnen, und validieren Sie das Schreibschutz‑Passwort separat, wenn eine Änderungs­berechtigung erforderlich ist.