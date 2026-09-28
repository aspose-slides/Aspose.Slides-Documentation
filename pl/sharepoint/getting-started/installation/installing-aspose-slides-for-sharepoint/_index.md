---
title: Instalowanie Aspose.Slides dla SharePoint
type: docs
weight: 10
url: /pl/sharepoint/installing-aspose-slides-for-sharepoint/
description: "Zainstaluj Aspose.Slides for SharePoint w farmie SharePoint: wybierz program instalacyjny odpowiadający Twojej wersji SharePoint, uruchom kontrolę systemu oraz wdroż i aktywuj rozwiązanie."
---
## **Zawartość pakietu**

Aspose.Slides for SharePoint jest pobierany ze [strony pobierania](https://releases.aspose.com/slides/sharepoint/) jako archiwum ZIP. Archiwum zawiera jedną paczkę rozwiązania SharePoint (WSP) i program instalacyjny dla każdej obsługiwanej wersji SharePoint:

| SharePoint version | Setup program | Solution package |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

Każdy program instalacyjny ma obok siebie plik konfiguracyjny (na przykład *Setup2019.exe.config*), w którym podana jest nazwa instalowanej paczki rozwiązania. Folder *License* zawiera odnośnik do umowy licencyjnej użytkownika końcowego oraz informacje o licencjach podmiotów trzecich.

Aspose.Slides for SharePoint jest pakowany jako rozwiązanie SharePoint, które SharePoint wdraża w całej farmie serwerów. Jego funkcja jest następnie aktywowana lub dezaktywowana w ramach kolekcji witryn.

## **Proces instalacji**

Przed instalacją program instalacyjny wykonuje kontrolę systemu. Sprawdza on, czy:

- SharePoint jest zainstalowany na serwerze.
- bieżący użytkownik posiada uprawnienia do instalacji i wdrażania rozwiązań SharePoint.
- usługa SharePoint Administration jest uruchomiona.
- usługa SharePoint Timer jest uruchomiona.
- paczka rozwiązania wskazana w pliku konfiguracyjnym jest dostępna.

Usługi Administration i Timer są potrzebne, ponieważ niektóre akcje instalacyjne są wykonywane jako zadania timera, które propagują rozwiązanie do wszystkich serwerów w farmie.

### **Uruchamianie instalacji**

Aby zainstalować Aspose.Slides for SharePoint:

1. Rozpakuj archiwum ZIP na lokalnym dysku serwera w farmie SharePoint.
2. Uruchom program instalacyjny odpowiadający Twojej wersji SharePoint (patrz tabela powyżej) i postępuj zgodnie z instrukcjami wyświetlanymi na ekranie. Program instalacyjny:
   1. Wykonuje kontrolę systemu. Instalacja nie jest kontynuowana, jeśli jakikolwiek test zakończy się niepowodzeniem.

      **Running a system check**

      ![The System Check screen of the setup program](installing-aspose-slides-for-sharepoint_1.png)

   2. Wyświetla umowę licencyjną użytkownika końcowego. Musisz ją zaakceptować, aby kontynuować.

      **The license agreement**

      ![The license agreement screen of the setup program](installing-aspose-slides-for-sharepoint_2.png)

   3. Wyświetla cele wdrożenia. Wybierz aplikacje internetowe i kolekcje witryn, dla których chcesz aktywować funkcję.

      **Selecting deployment targets**

      ![The Site Collection Deployment Targets screen of the setup program](installing-aspose-slides-for-sharepoint_3.png)

   4. Wdraża rozwiązanie w farmie.

      **The installation progress**

      ![The installation progress screen of the setup program](installing-aspose-slides-for-sharepoint_4.png)

   5. Aktywuje Aspose.Slides for SharePoint w wybranych kolekcjach witryn.
   6. Wyświetla listę aplikacji internetowych i kolekcji witryn, w których rozwiązanie zostało wdrożone i aktywowane.

      **Successful installation**

      ![The installation completed screen of the setup program](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Note" %}}
Zrzuty ekranu zostały wykonane w SharePoint 2007. Programy instalacyjne dla późniejszych wersji przechodzą przez te same ekrany.
{{% /alert %}}

Jeśli ta sama wersja Aspose.Slides for SharePoint jest już zainstalowana, program instalacyjny zaoferuje jej naprawę lub usunięcie. Jeśli zainstalowana jest inna wersja, zostanie zaoferowana aktualizacja lub usunięcie.

Po instalacji w menu plików w bibliotekach dokumentów wybranych kolekcji witryn pojawia się pozycja **Convert via Aspose.Slides** (w SharePoint 2007 **Convert with Aspose.Slides**). Aby przekonwertować pierwszą prezentację, zobacz [Converting Microsoft PowerPoint Documents into Other Formats](/slides/pl/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/). To, co rozwiązanie dodaje do farmy, opisano w [Deployment and Activation](/slides/pl/sharepoint/deployment-and-activation/).

## **FAQ**

**Which setup program do I run?**

Ten, którego nazwa odpowiada Twojej wersji SharePoint. Na przykład uruchom *Setup2016.exe* w farmie SharePoint Server 2016. Każdy program instalacyjny instaluję wyłącznie własną paczkę rozwiązania.

**Do I need a separate download for the licensed version?**

Nie. Ten sam pakiet działa w trybie ewaluacyjnym, dopóki nie zainstalujesz rozwiązania licencyjnego; zobacz [Installing Aspose.Slides for SharePoint License](/slides/pl/sharepoint/installing-aspose-slides-for-sharepoint-license/).

**How do I remove the product?**

Uruchom ponownie ten sam program instalacyjny i wybierz **Remove**; zobacz [Uninstalling Aspose.Slides for SharePoint](/slides/pl/sharepoint/uninstalling-aspose-slides-for-sharepoint/).