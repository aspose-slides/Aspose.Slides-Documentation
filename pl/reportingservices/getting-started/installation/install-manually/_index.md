---  
title: Instalacja ręczna  
type: docs  
weight: 30  
url: /pl/reportingservices/install-manually/  
keywords:  
- instalacja ręczna  
- rsreportserver.config  
- rssrvpolicy.config  
- SQL Server Reporting Services  
- Power BI Report Server  
- Aspose.Slides for Reporting Services  
description: "Zainstaluj Aspose.Slides for Reporting Services ręcznie z pakietu ZIP zawierającego tylko pliki DLL: którą bibliotekę skopiować i co dodać do rsreportserver.config oraz rssrvpolicy.config."  
---
## **Przegląd**

Postępuj zgodnie z poniższymi krokami, aby zainstalować Aspose.Slides for Reporting Services bez instalatora MSI, z pakietu ZIP *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* znajdującego się na [stronie pobierania](https://releases.aspose.com/slides/pl/reportingservices/). Rejestrują one te same rozszerzenia co [instalator MSI](/slides/pl/reportingservices/install-with-msi-installer/). Powtórz je dla każdej instancji serwera raportów.

Przed rozpoczęciem sprawdź [wymagania systemowe](/slides/pl/reportingservices/system-requirements/). Potrzebujesz lokalnych uprawnień administratora na serwerze raportów.

## **Wybierz zestaw**

Pakiet ZIP zawiera kilka kompilacji. Skopiuj dokładnie jeden plik *Aspose.Slides.ReportingServices.dll* na serwer raportów:

| Plik w pakiecie ZIP | Zastosowanie |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | Reporting Services SQL Server 2008 i nowsze oraz Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | Reporting Services SQL Server 2005 |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | Nie przeznaczony dla serwera raportów: aplikacje eksportujące z kontrolki ReportViewer 2010 lub 2012, zobacz [Używanie Aspose.Slides z ReportViewer 2010 i 2012](/slides/pl/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | Opcjonalnie: zapisuje raporty w formacie RPL dla raportów problemowych, zobacz [Eksportowanie raportów do formatu RPL](/slides/pl/reportingservices/exporting-reports-to-rpl-format/) |

## **Znajdź folder serwera raportów**

Poniższe kroki odnoszą się do folderu *ReportServer* serwera raportów, w którym znajdują się pliki *rsreportserver.config* i *rssrvpolicy.config*. W instalacji domyślnej jest to:

| Serwer raportów | Domyślny folder *ReportServer* |
| :- | :- |
| SQL Server 2017 i nowsze Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 i wcześniejsze Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`, gdzie folder instancji to np. `MSRS13.MSSQLSERVER` dla SQL Server 2016 lub `MSSQL.x` dla SQL Server 2005 |

Aby poznać więcej lokalizacji, zobacz artykuł Microsoftu o [pliku konfiguracyjnym RsReportServer.config](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file).

## **Zainstaluj rozszerzenie**

1. Skopiuj wybraną assembly do podfolderu *bin* folderu *ReportServer*.

   Skopiowany plik nie może mieć jawnie przypisanych uprawnień NTFS, w przeciwnym razie serwer raportów nie uzyska dostępu podczas ładowania assembly i nowe formaty eksportu nie pojawią się. Kliknij prawym przyciskiem plik, wybierz **Properties**, a na karcie **Security** usuń wszystkie jawnie przypisane uprawnienia, pozostawiając tylko dziedziczone. Jeśli na karcie **General** widoczna jest opcja **Unblock**, zaznacz ją.

2. Zapisz kopię pliku *rsreportserver.config*, a następnie otwórz go w edytorze tekstu. Dodaj poniższe wpisy wewnątrz elementu `<Render>`:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   Każdy wpis rejestruje jeden format eksportu; `Name` musi być unikalny wśród rozszerzeń renderujących. Instalator MSI rejestruje te same sześć nazw i typów. Pomiń wpis, jeśli nie chcesz, aby dany format pojawił się na liście eksportu.

3. Zapisz kopię pliku *rssrvpolicy.config*, a następnie otwórz go w edytorze tekstu. Znajdź grupę kodu, której `Description` brzmi "This code group grants MyComputer code Execution permission." i dodaj tę grupę kodu jako jej ostatnie dziecko:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` to klucz publiczny assembly Aspose.Slides.ReportingServices. Zachowaj go w jednej linii.

4. Zapisz oba pliki. Serwer raportów ponownie odczytuje pliki konfiguracyjne przy każdym ich zapisaniu. Jeśli plik zawiera nieprawidłowy XML, serwer raportów go zignoruje lub nie uruchomi się, więc w razie problemów przywróć swoją kopię.

## **Sprawdź instalację**

Otwórz raport paginowany w portalu internetowym (Report Manager w SQL Server 2014 i starszych) i otwórz listę **Export**. Teraz zawiera ona następujące formaty:

- PPT – prezentacja PowerPoint przy użyciu Aspose.Slides
- PPS – pokaz slajdów PowerPoint przy użyciu Aspose.Slides
- PPTX – prezentacja PowerPoint 2007 przy użyciu Aspose.Slides
- PPSX – pokaz slajdów PowerPoint 2007 przy użyciu Aspose.Slides
- ODP – prezentacja OpenDocument przy użyciu Aspose.Slides
- XPS – przy użyciu Aspose.Slides

Wybierz jeden z nich, aby wyeksportować raport. Plik otwiera się w aplikacji skojarzonej z danym formatem.

![Raport wyeksportowany do PowerPoint za pomocą Aspose.Slides for Reporting Services](install-manually_2.png)

Jeśli formaty się nie pojawiają, sprawdź uprawnienia NTFS skopiowanej assembly. Bez licencji wyeksportowane pliki zawierają znak wodny wersji ewaluacyjnej; zobacz [Licencjonowanie](/slides/pl/reportingservices/license-aspose-slides-for-reporting-services/).