---
title: Präsentation über VBA
type: docs
weight: 250
url: /php-java/presentation-via-vba/
keywords: "Makro, makros, VBA, VBA-Makro, Makro hinzufügen, Makro entfernen, VBA hinzufügen, VBA entfernen, Makro extrahieren, VBA extrahieren, PowerPoint-Makro, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Hinzufügen, Entfernen und Extrahieren von VBA-Makros in PowerPoint-Präsentationen"
---

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie eine Präsentation, die Makros enthält, in ein anderes Dateiformat (PDF, HTML usw.) konvertieren, ignoriert Aspose.Slides alle Makros (Makros werden nicht in die resultierende Datei übertragen).

Wenn Sie Makros zu einer Präsentation hinzufügen oder eine Präsentation mit Makros erneut speichern, schreibt Aspose.Slides einfach die Bytes für die Makros.

Aspose.Slides **führt niemals** die Makros in einer Präsentation aus.

{{% /alert %}}

## **VBA-Makros hinzufügen**

Aspose.Slides bietet die [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/) Klasse, um Ihnen zu ermöglichen, VBA-Projekte (und Projektverweise) zu erstellen und vorhandene Module zu bearbeiten. Sie können die [IVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/ivbaproject/) Schnittstelle verwenden, um VBA, das in einer Präsentation eingebettet ist, zu verwalten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Verwenden Sie den [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject--) Konstruktor, um ein neues VBA-Projekt hinzuzufügen.
1. Fügen Sie ein Modul zum VbaProject hinzu.
1. Legen Sie den Quellcode des Moduls fest.
1. Fügen Sie Referenzen zu <stdole> hinzu.
1. Fügen Sie Referenzen zu **Microsoft Office** hinzu.
1. Verknüpfen Sie die Referenzen mit dem VBA-Projekt.
1. Speichern Sie die Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie ein VBA-Makro von Grund auf zu einer Präsentation hinzufügen:

```php
  # Erstellt eine Instanz der Präsentationsklasse
  $pres = new Presentation();
  try {
    # Erstellt ein neues VBA-Projekt
    $pres->setVbaProject(new VbaProject());
    # Fügt ein leeres Modul zum VBA-Projekt hinzu
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # Legt den Quellcode des Moduls fest
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # Erstellt eine Referenz zu <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Erstellt eine Referenz zu Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # Fügt die Referenzen zum VBA-Projekt hinzu
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

Sie möchten vielleicht **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros) ausprobieren, eine kostenlose Webanwendung, die verwendet wird, um Makros aus PowerPoint-, Excel- und Word-Dokumenten zu entfernen. 

{{% /alert %}} 

## **VBA-Makros entfernen**

Mit der [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject--) Eigenschaft der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse können Sie ein VBA-Makro entfernen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse und laden Sie die Präsentation, die das Makro enthält.
1. Greifen Sie auf das Makromodul zu und entfernen Sie es.
1. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie ein VBA-Makro entfernen:

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

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse und laden Sie die Präsentation, die das Makro enthält.
2. Überprüfen Sie, ob die Präsentation ein VBA-Projekt enthält.
3. Durchlaufen Sie alle Module, die im VBA-Projekt enthalten sind, um die Makros anzuzeigen.

Dieser PHP-Code zeigt Ihnen, wie Sie VBA-Makros aus einer Präsentation mit Makros extrahieren:

```php
  # Lädt die Präsentation, die das Makro enthält
  $pres = new Presentation("VBA.pptm");
  try {
    # Überprüft, ob die Präsentation ein VBA-Projekt enthält
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