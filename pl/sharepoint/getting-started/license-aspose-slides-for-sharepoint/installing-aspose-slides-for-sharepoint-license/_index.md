---
title: Instalacja licencji Aspose.Slides dla SharePoint
type: docs
weight: 10
url: /pl/sharepoint/installing-aspose-slides-for-sharepoint-license/
---
{{% alert color="primary" %}} 

Gdy będziesz zadowolony z wersji ewaluacyjnej, możesz [zakup licencję](https://purchase.aspose.com/buy). Przed zakupem upewnij się, że rozumiesz i zgadzasz się na warunki subskrypcji licencji. Licencja zostanie wysłana e‑mailem po opłaceniu zamówienia.

Licencja jest archiwum ZIP zawierającym standardowy pakiet rozwiązania SharePoint. Archiwum zawiera:

- Aspose.Slides.SharePoint.License.wsp – plik pakietu rozwiązania SharePoint. Licencja jest pakowana jako rozwiązanie SharePoint, aby ułatwić wdrażanie i wycofywanie w farmie serwerów.
- readme.txt – instrukcje instalacji licencji.

{{% /alert %}} 
## **Instalacja licencji**
Instalacja licencji jest wykonywana z konsoli serwera przy użyciu **stsadm.exe**.

{{% alert color="primary" %}} 

Ścieżki zostały pominięte w poniższej sekcji dla przejrzystości.

{{% /alert %}} 

Wykonaj następujące kroki, aby wdrożyć licencję Aspose.Slides for SharePoint:

1. Uruchom stsadm, aby dodać rozwiązanie do magazynu rozwiązań SharePoint: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. Wdróż rozwiązanie na wszystkich serwerach w farmie: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. Uruchom zadania timerów administracyjnych, aby natychmiast zakończyć wdrażanie: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

Podczas uruchamiania kroku wdrożenia otrzymasz ostrzeżenie, jeśli usługa Windows SharePoint Services Administration nie jest uruchomiona. **stsadm.exe** polega na tej usłudze oraz na Windows SharePoint Timer Service, aby replikować dane rozwiązania w całej farmie. Jeśli te usługi nie działają w Twojej farmie serwerów, może być konieczne wdrożenie licencji na każdym serwerze. 

{{% /alert %}} 
## **Testowanie licencji**
Aby przetestować, czy licencja została prawidłowo zainstalowana, skonwertuj dowolny dokument do nowego formatu. Jeśli w dokumencie nie ma znaku wodnego wersji ewaluacyjnej, licencja została pomyślnie aktywowana.