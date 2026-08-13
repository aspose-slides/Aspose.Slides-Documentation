---
title: "Verwalten von VBA-Projekten in Präsentationen mit C++"
linktitle: "Präsentation über VBA"
type: docs
weight: 250
url: /de/cpp/presentation-via-vba/
keywords:
- "Makro"
- "VBA"
- "VBA-Makro"
- "Makro hinzufügen"
- "Makro entfernen"
- "Makro extrahieren"
- "VBA hinzufügen"
- "VBA entfernen"
- "VBA extrahieren"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "C++"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen über VBA mit Aspose.Slides für C++ erstellen und manipulieren, um Ihren Arbeitsablauf zu optimieren."
---
## **Einführung**

Der Namespace [Aspose.Slides.Vba](https://reference.aspose.com/slides/de/cpp/namespace/aspose.slides.vba/) enthält Klassen und Schnittstellen zum Arbeiten mit Makros und VBA‑Code.

{{% alert title="Note" color="warning" %}} 

Wenn Sie eine Präsentation, die Makros enthält, in ein anderes Dateiformat (PDF, HTML usw.) konvertieren, ignoriert Aspose.Slides alle Makros (Makros werden nicht in die resultierende Datei übernommen).

Wenn Sie einer Präsentation Makros hinzufügen oder eine Präsentation, die Makros enthält, erneut speichern, schreibt Aspose.Slides einfach die Bytes für die Makros.

Aspose.Slides führt **niemals** die Makros in einer Präsentation aus.

{{% /alert %}}

## **VBA‑Makros hinzufügen**

Aspose.Slides stellt die Klasse [VbaProject](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.vba.vba_project) bereit, mit der Sie VBA‑Projekte (und Projektverweise) erstellen und vorhandene Module bearbeiten können. Sie können das Interface [IVbaProject](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.vba.i_vba_project/) verwenden, um in einer Präsentation eingebettetes VBA zu verwalten.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation).
1. Verwenden Sie den Konstruktor der [VbaProject](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b)-Klasse, um ein neues VBA‑Projekt hinzuzufügen.
1. Fügen Sie dem VbaProject ein Modul hinzu.
1. Legen Sie den Quellcode des Moduls fest.
1. Fügen Sie Verweise zu <stdole> hinzu.
1. Fügen Sie Verweise zu **Microsoft Office** hinzu.
1. Verknüpfen Sie die Verweise mit dem VBA‑Projekt.
1. Speichern Sie die Präsentation.

Dieser C++‑Code zeigt, wie Sie ein VBA‑Makro von Grund auf zu einer Präsentation hinzufügen: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaReferenceCollection.h>
#include <DOM/Vba/VbaProject.h>
#include <DOM/Vba/VbaReferenceOleTypeLib.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Vba;
using namespace System;

// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Erstellt eine Instanz der Presentation‑Klasse
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Erstellt ein neues VBA‑Projekt
presentation->set_VbaProject(MakeObject<VbaProject>());

// Fügt dem VBA‑Projekt ein leeres Modul hinzu
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Setzt den Quellcode des Moduls
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Erstellt einen Verweis auf <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Erstellt einen Verweis auf Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Fügt Verweise zum VBA‑Projekt hinzu
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Speichert die Präsentation
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="info" %}} 

Vielleicht möchten Sie den **Aspose**‑[Macro Remover](https://products.aspose.app/slides/de/remove-macros) ausprobieren, eine kostenlose Web‑App zum Entfernen von Makros aus PowerPoint‑, Excel‑ und Word‑Dokumenten. 

{{% /alert %}} 

## **VBA‑Makros entfernen**

Mit der [VbaProject](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4)-Eigenschaft der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation) können Sie ein VBA‑Makro entfernen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation) und laden Sie die Präsentation, die das Makro enthält.
1. Greifen Sie auf das Makro‑Modul zu und entfernen Sie es.
1. Speichern Sie die geänderte Präsentation.

Dieser C++‑Code zeigt, wie Sie ein VBA‑Makro entfernen: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Loads the presentation containing the macro
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Accesses the Vba module and removes it
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Saves the Presentation
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **VBA‑Makros extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation)‑Klasse und laden Sie die Präsentation, die das Makro enthält.
2. Prüfen Sie, ob die Präsentation ein VBA‑Projekt enthält.
3. Durchlaufen Sie alle im VBA‑Projekt enthaltenen Module, um die Makros anzuzeigen.

Dieser C++‑Code zeigt, wie Sie VBA‑Makros aus einer Präsentation mit Makros extrahieren: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

	// Der Pfad zum Dokumentenverzeichnis.
	const String templatePath = u"../templates/VBA.pptm";

	// Lädt die Präsentation, die das Makro enthält
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Überprüft, ob die Präsentation ein VBA‑Projekt enthält
	{
		
		//for (SharedPtr<IVbaModule> module : pres->get_VbaProject()->get_Modules())
		for (int i = 0; i < pres->get_VbaProject()->get_Modules()->get_Count(); i++)
		{
			SharedPtr<IVbaModule> module = pres->get_VbaProject()->get_Modules()->idx_get(i);

			System::Console::WriteLine(module->get_Name());
			System::Console::WriteLine(module->get_SourceCode());
		}
	}
```

## **Prüfen, ob ein VBA‑Projekt passwortgeschützt ist**

Mit der Eigenschaft [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/de/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) können Sie feststellen, ob die Eigenschaften eines Projekts passwortgeschützt sind.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) und laden Sie eine Präsentation, die ein Makro enthält.
2. Prüfen Sie, ob die Präsentation ein [VBA project](https://reference.aspose.com/slides/de/cpp/aspose.slides.vba/vbaproject/) enthält.
3. Prüfen Sie, ob das VBA‑Projekt passwortgeschützt ist, um seine Eigenschaften anzuzeigen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Prüft, ob die Präsentation ein VBA‑Projekt enthält.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **FAQ**

### Was passiert mit Makros, wenn ich die Präsentation als PPTX speichere?

Makros werden entfernt, weil PPTX kein VBA unterstützt. Um Makros zu behalten, wählen Sie PPTM, PPSM oder POTM.

### Kann Aspose.Slides Makros in einer Präsentation ausführen, um beispielsweise Daten zu aktualisieren?

Nein. Die Bibliothek führt niemals VBA‑Code aus; die Ausführung ist nur innerhalb von PowerPoint mit den entsprechenden Sicherheitseinstellungen möglich.

### Wird die Arbeit mit ActiveX‑Steuerelementen, die an VBA‑Code gebunden sind, unterstützt?

Ja, Sie können vorhandene [ActiveX‑Steuerelemente](/slides/de/cpp/activex/) aufrufen, deren Eigenschaften ändern und sie entfernen. Dies ist nützlich, wenn Makros mit ActiveX interagieren.