---
title: Instalowanie licencji Aspose.Slides dla SharePoint
type: docs
weight: 10
url: /pl/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "Zainstaluj licencję Aspose.Slides dla SharePoint w farmie SharePoint: dodaj rozwiązanie licencyjne do magazynu rozwiązań, wdroż je i sprawdź, czy przekonwertowane pliki nie zawierają już znaku wodnego oceny."
---
{{% alert color="info" title="Note" %}}

Gdy będziesz zadowolony z oceny, możesz [zakupić licencję](https://purchase.aspose.com/pricing/slides/sharepoint/). Przed zakupem upewnij się, że rozumiesz i akceptujesz warunki subskrypcji licencji. Licencja zostanie wysłana do Ciebie pocztą elektroniczną po opłaceniu zamówienia.

Licencja jest archiwum ZIP zawierającym standardowy pakiet rozwiązania SharePoint. Archiwum zawiera:

- Aspose.Slides.SharePoint.License.wsp – plik pakietu rozwiązania SharePoint. Licencja jest pakowana jako rozwiązanie SharePoint, aby ułatwić wdrażanie i wycofywanie w farmie serwerów.
- readme.txt – instrukcje instalacji licencji.

{{% /alert %}}

## **Wdrażanie licencji**

Instalacja licencji jest wykonywana z konsoli serwera przy użyciu **stsadm.exe**.

{{% alert color="info" title="Note" %}}

Ścieżki zostały pominięte w następującej sekcji dla przejrzystości.

{{% /alert %}}

Wykonaj następujące kroki, aby wdrożyć licencję Aspose.Slides dla SharePoint:

1. Uruchom stsadm, aby dodać rozwiązanie do magazynu rozwiązań SharePoint:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. Wdróż rozwiązanie na wszystkich serwerach w farmie:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. Uruchom zadania timerów administracyjnych, aby natychmiast zakończyć wdrażanie:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

Operacja `addsolution` przyjmuje ścieżkę do pliku rozwiązania w parametrze `-filename`; operacja `deploysolution` przyjmuje nazwę rozwiązania, które już znajduje się w magazynie rozwiązań, w parametrze `-name`.

{{% alert color="info" title="Note" %}}

Otrzymasz ostrzeżenie podczas wykonywania kroku wdrożenia, jeśli usługa administracji SharePoint nie jest uruchomiona. **stsadm.exe** zależy od tej usługi oraz usługi SharePoint Timer, aby replikować dane rozwiązania w całej farmie. Jeśli te usługi nie działają w Twojej farmie serwerów, może być konieczne wdrożenie licencji na każdym serwerze.

{{% /alert %}}

{{% alert color="info" title="Note" %}}

W SharePoint 2010 i nowszych, cmdlety SharePoint Management Shell `Add-SPSolution`, `Install-SPSolution` i `Start-SPAdminJob` odpowiadają operacjom `addsolution`, `deploysolution` oraz `execadmsvcjobs`. Zobacz [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **Testowanie licencji**

Aby przetestować, czy licencja została poprawnie zainstalowana, przekonwertuj dowolną prezentację na nowy format. Jeśli w przekonwertowanym pliku nie ma znaku wodnego oceny, licencja jest aktywna.