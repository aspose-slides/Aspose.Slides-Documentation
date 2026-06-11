---
title: Instalacja Aspose.Slides dla SharePoint
type: docs
weight: 10
url: /pl/sharepoint/installing-aspose-slides-for-sharepoint/
---
{{% alert color="primary" %}} 

Aspose.Slides for SharePoint jest pobierany jako archiwum Aspose.Slides.SharePoint.zip. Archiwum zawiera: 

- **Aspose.Slides.SharePoint.wsp**: plik rozwiązania SharePoint. Aspose.Slides for SharePoint jest pakowany jako rozwiązanie SharePoint, aby ułatwić aktywację i dezaktywację w całej farmie serwerów.
- **Aspose_LicenseAgreement.rtf**: Umowa licencyjna użytkownika końcowego.
- **Setup.exe**: program instalacyjny.
- **Setup.exe.config**: plik konfiguracyjny instalacji.

{{% /alert %}} 
## **Proces instalacji**
Przed uruchomieniem instalacji program instalacyjny sprawdza, czy:

- Zainstalowano WSS 3.0 lub MOSS 2007.
- Użytkownik ma uprawnienia do instalacji rozwiązań SharePoint.
- Baza danych SharePoint jest online.
- Usługa WSS Administration jest uruchomiona.
- Usługa WSS Timer jest uruchomiona.

Usługi WSS Administration i Timer są potrzebne, ponieważ niektóre działania instalacyjne opierają się na zadaniu timerowym, które ma się rozprzestrzenić na wszystkie serwery w farmie. 
### **Uruchamianie instalacji**
Aby zainstalować Aspose.Slides for SharePoint: 

1. Rozpakuj archiwum Aspose.Slides.SharePoint na lokalnym dysku serwera MOSS 7.0 lub WSS 3.0.
2. Uruchom setup.exe i postępuj zgodnie z instrukcjami wyświetlanymi na ekranie.
   Program instalacyjny wykonuje następujące działania:
   1. Sprawdza wymagania wstępne instalacji. Instalacja nie będzie kontynuowana, jeśli którykolwiek z testów nie powiedzie się. 

      **Uruchamianie kontroli systemu** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_1.png)




3. Wyświetla umowę licencyjną użytkownika końcowego. Musisz zaakceptować umowę, aby kontynuować. 

   **Umowa EULA** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_2.png)




4. Wyświetla wybór docelowego wdrożenia. Wybiera aplikacje internetowe i kolekcje witryn, dla których funkcja ma być aktywowana. 

   **Wybór celów wdrożenia** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_3.png)




5. Wdraża funkcję w farmie serwerów. 

   **Pasek postępu instalacji** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_4.png)




6. Aktywuje Aspose.Slides dla wybranych kolekcji witryn i konfiguruje ich nadrzędne aplikacje internetowe.
7. Wyświetla listę aplikacji internetowych i kolekcji witryn, dla których funkcja została wdrożona i aktywowana. 

   **Pomyślna instalacja** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_5.png)