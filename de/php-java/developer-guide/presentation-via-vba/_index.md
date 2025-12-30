---
title: VBA-Projekte in Präsentationen mit PHP verwalten
linktitle: Präsentation via VBA
type: docs
weight: 250
url: /de/php-java/presentation-via-vba/
keywords:
- Makro
- VBA
- VBA-Makro
- Makro hinzufügen
- Makro entfernen
- Makro extrahieren
- VBA hinzufügen
- VBA entfernen
- VBA extrahieren
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen via VBA mit Aspose.Slides für PHP via Java erstellen und bearbeiten, um Ihren Arbeitsablauf zu optimieren."
---

{{% alert title="Note" color="warning" %}} 

Wenn Sie eine Präsentation, die Makros enthält, in ein anderes Dateiformat (PDF, HTML usw.) konvertieren, ignoriert Aspose.Slides alle Makros (Makros werden nicht in die resultierende Datei übernommen).

Wenn Sie einer Präsentation Makros hinzufügen oder eine Präsentation, die Makros enthält, erneut speichern, schreibt Aspose.Slides einfach die Bytes für die Makros.

Aspose.Slides **führt die Makros in einer Präsentation niemals aus**.

{{% /alert %}}

## **VBA-Makros hinzufügen**

Aspose.Slides stellt die Klasse [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/) bereit, um VBA‑Projekte (und Projektverweise) zu erstellen und vorhandene Module zu bearbeiten. Sie können das Interface [IVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/ivbaproject/) verwenden, um VBA, das in einer Präsentation eingebettet ist, zu verwalten.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Verwenden Sie den [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject--)‑Konstruktor, um ein neues VBA‑Projekt hinzuzufügen.
1. Fügen Sie dem VbaProject ein Modul hinzu.
1. Legen Sie den Quellcode des Moduls fest.
1. Fügen Sie Verweise zu <stdole> hinzu.
1. Fügen Sie Verweise zu **Microsoft Office** hinzu.
1. Verknüpfen Sie die Verweise mit dem VBA‑Projekt.
1. Speichern Sie die Präsentation.

Dieser PHP‑Code zeigt, wie Sie ein VBA‑Makro von Grund auf zu einer Präsentation hinzufügen:
```php
  # Erstellt eine Instanz der Präsentationsklasse
  $pres = new Presentation();
  try {
    # Erstellt ein neues VBA-Projekt
    $pres->setVbaProject(new VbaProject());
    # Fügt dem VBA-Projekt ein leeres Modul hinzu
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # Setzt den Quellcode des Moduls
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # Erstellt einen Verweis auf <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Erstellt einen Verweis auf Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # Fügt Verweise zum VBA-Projekt hinzu
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # Speichert die Präsentation
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

Vielleicht möchten Sie den **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros) ausprobieren, eine kostenlose Web‑App zum Entfernen von Makros aus PowerPoint‑, Excel‑ und Word‑Dokumenten. 

{{% /alert %}} 

## **VBA-Makros entfernen**

Über die Eigenschaft [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject--) der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) können Sie ein VBA‑Makro entfernen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) und laden Sie die Präsentation, die das Makro enthält.
1. Greifen Sie auf das Makro‑Modul zu und entfernen Sie es.
1. Speichern Sie die geänderte Präsentation.

Dieser PHP‑Code zeigt, wie Sie ein VBA‑Makro entfernen:
```php
  # Lädt die Präsentation, die das Makro enthält
  $pres = new Presentation("VBA.pptm");
  try {
    # Greift auf das Vba-Modul zu und entfernt es
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Speichert die Präsentation
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **VBA-Makros extrahieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) und laden Sie die Präsentation, die das Makro enthält.
2. Prüfen Sie, ob die Präsentation ein VBA‑Projekt enthält.
3. Durchlaufen Sie alle im VBA‑Projekt enthaltenen Module, um die Makros einzusehen.

Dieser PHP‑Code zeigt, wie Sie VBA‑Makros aus einer Präsentation mit Makros extrahieren:
```php
  # Lädt die Präsentation, die das Makro enthält
  $pres = new Presentation("VBA.pptm");
  try {
    # Prüft, ob die Präsentation ein VBA-Projekt enthält
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Überprüfen, ob ein VBA-Projekt passwortgeschützt ist**

Mit der Methode [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#isPasswordProtected) können Sie feststellen, ob die Eigenschaften eines Projekts passwortgeschützt sind.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und laden Sie eine Präsentation, die ein Makro enthält.
2. Prüfen Sie, ob die Präsentation ein [VBA‑Projekt](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/) enthält.
3. Prüfen Sie, ob das VBA‑Projekt passwortgeschützt ist, um seine Eigenschaften anzuzeigen.
```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // Prüfen, ob die Präsentation ein VBA-Projekt enthält.
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**Was passiert mit Makros, wenn ich die Präsentation als PPTX speichere?**

Makros werden entfernt, da PPTX kein VBA unterstützt. Um Makros zu behalten, wählen Sie PPTM, PPSM oder POTM.

**Kann Aspose.Slides Makros in einer Präsentation ausführen, um beispielsweise Daten zu aktualisieren?**

Nein. Die Bibliothek führt niemals VBA‑Code aus; die Ausführung ist nur innerhalb von PowerPoint mit den entsprechenden Sicherheitseinstellungen möglich.

**Werden ActiveX‑Steuerelemente, die mit VBA‑Code verknüpft sind, unterstützt?**

Ja, Sie können vorhandene [ActiveX‑Steuerelemente](/slides/de/php-java/activex/) zugreifen, deren Eigenschaften ändern und sie entfernen. Das ist nützlich, wenn Makros mit ActiveX interagieren.