---
title: Wdrożenie i Aktywacja
type: docs
weight: 20
url: /pl/sharepoint/deployment-and-activation/
---
## **Wdrożenie**
Podczas wdrożenia Aspose.Slides for SharePoint: 

- Instaluje **Aspose.Slides.SharePoint.dll** w Global Assembly Cache i dodaje wpis SafeControl do pliku **web.config**.
- Instaluje manifest funkcji oraz inne niezbędne pliki w odpowiednich katalogach.
- Rejestruje funkcję w bazie danych SharePoint i udostępnia ją do aktywacji w zakresie funkcji.
## **Aktywacja**
Aspose.Slides for SharePoint jest pakowany jako funkcja na poziomie witryny (kolekcji witryn) i może być aktywowana lub dezaktywowana w kolekcjach witryn. Podczas aktywacji funkcja wprowadza pewne zmiany w wirtualnym katalogu nadrzędnej aplikacji internetowej kolekcji witryn. Wykonuje ona: 

- Dodaje stronę ustawień konwersji do pliku mapy witryny.
- Kopiuje niezbędne pliki zasobów do folderu App_GlobalResources w wirtualnym katalogu.