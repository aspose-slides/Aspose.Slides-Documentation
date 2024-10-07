---
title: Präsentation über VBA
type: docs
weight: 250
url: /cpp/presentation-via-vba/
keywords: "Makro, Makros, VBA, VBA-Makro, Makro hinzufügen, Makro entfernen, VBA hinzufügen, VBA entfernen, Makro extrahieren, VBA extrahieren, PowerPoint-Makro, PowerPoint-Präsentation, C++, CPP, Aspose.Slides für C++"
description: "Fügen Sie VBA-Makros in PowerPoint-Präsentationen in C++ hinzu, entfernen und extrahieren Sie sie."
---

Der [Aspose.Slides.Vba](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.vba/) Namensraum enthält Klassen und Schnittstellen für die Arbeit mit Makros und VBA-Code.

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie eine Präsentation, die Makros enthält, in ein anderes Dateiformat (PDF, HTML usw.) konvertieren, ignoriert Aspose.Slides alle Makros (Makros werden nicht in die resultierende Datei übertragen).

Wenn Sie Makros zu einer Präsentation hinzufügen oder eine Präsentation mit Makros erneut speichern, schreibt Aspose.Slides einfach die Bytes für die Makros.

Aspose.Slides **führt niemals** die Makros in einer Präsentation aus.

{{% /alert %}}

## **VBA-Makros hinzufügen**

Aspose.Slides bietet die [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project) Klasse, die es Ihnen ermöglicht, VBA-Projekte (und Projektverweise) zu erstellen und vorhandene Module zu bearbeiten. Sie können die [IVbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.i_vba_project/) Schnittstelle verwenden, um VBA, das in einer Präsentation eingebettet ist, zu verwalten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Verwenden Sie den [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) Konstruktor, um ein neues VBA-Projekt hinzuzufügen.
1. Fügen Sie ein Modul zum VbaProject hinzu.
1. Setzen Sie den Quellcode des Moduls.
1. Fügen Sie Verweise auf <stdole> hinzu.
1. Fügen Sie Verweise auf **Microsoft Office** hinzu.
1. Verknüpfen Sie die Verweise mit dem VBA-Projekt.
1. Speichern Sie die Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie ein VBA-Makro von Grund auf zu einer Präsentation hinzufügen: 

```c++

// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Erstellt eine Instanz der Präsentationsklasse
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Erstellt ein neues VBA-Projekt
presentation->set_VbaProject(MakeObject<VbaProject>());

// Fügt dem VBA-Projekt ein leeres Modul hinzu
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Setzt den Quellcode des Moduls
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Erstellt einen Verweis auf <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Erstellt einen Verweis auf Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Objektbibliothek");

// Fügt Verweise zum VBA-Projekt hinzu
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Speichert die Präsentation
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);

```

{{% alert color="primary" %}} 

Vielleicht möchten Sie **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros) ausprobieren, eine kostenlose Webanwendung, mit der Makros aus PowerPoint-, Excel- und Word-Dokumenten entfernt werden können. 

{{% /alert %}} 

## **VBA-Makros entfernen**

Mit der [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) Eigenschaft der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse können Sie ein VBA-Makro entfernen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse und laden Sie die Präsentation, die das Makro enthält.
1. Greifen Sie auf das Makro-Modul zu und entfernen Sie es.
1. Speichern Sie die modifizierte Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie ein VBA-Makro entfernen: 

```c++

// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Lädt die Präsentation, die das Makro enthält
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Greift auf das Vba-Modul zu und entfernt es 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Speichert die Präsentation
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);

```

## **VBA-Makros extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse und laden Sie die Präsentation, die das Makro enthält.
2. Überprüfen Sie, ob die Präsentation ein VBA-Projekt enthält.
3. Durchlaufen Sie alle Module, die im VBA-Projekt enthalten sind, um die Makros anzuzeigen.

Dieser C++-Code zeigt Ihnen, wie Sie VBA-Makros aus einer Präsentation extrahieren, die Makros enthält: 

```c++

	// Der Pfad zum Dokumentenverzeichnis.
	const String templatePath = u"../templates/VBA.pptm";

	// Lädt die Präsentation, die das Makro enthält
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Überprüft, ob die Präsentation ein VBA-Projekt enthält
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