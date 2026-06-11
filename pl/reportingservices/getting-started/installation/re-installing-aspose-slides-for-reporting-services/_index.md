---
title: Ponowna instalacja Aspose.Slides for Reporting Services
type: docs
weight: 40
url: /pl/reportingservices/re-installing-aspose-slides-for-reporting-services/
---
{{% alert color="primary" %}} 
Ten artykuł opisuje rozwiązanie sytuacji, w której Aspose.Slides for Reporting Services jest już zainstalowany, ale z jakiegoś powodu musi zostać ponownie zainstalowany.
{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 
**Aspose.Slides for Reporting Services** wymaga zainstalowania **.NET Framework 3.5** na komputerze gospodarza. 
{{% /alert %}}

## **Kroki ponownej instalacji Aspose.Slides for Reporting Services**
Najważniejsze jest całkowite usunięcie poprzednich instalacji Aspose.Slides for Reporting Services. Chociaż instalator MSI może wykonać niezbędne czynności odinstalowania i ponownej instalacji automatycznie, należy wykonać następujące kroki:

1. Odinstaluj Aspose.Slides for Reporting Services przy użyciu instalatora MSI. 

2. Zlokalizuj katalog instalacyjny Aspose.Slides for Reporting Services, który zazwyczaj znajduje się w:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3. Jeśli instalator MSI nie usunął katalogu “Aspose.Slides for Reporting Services” podczas odinstalowywania Aspose.Slides for Reporting Services, usuń ten folder. 

4. Zlokalizuj plik binarny **Aspose.Slides.ReportingServices.dll** w katalogu „bin” każdej instancji SQL Server Reporting Service. Na przykład, jeśli istnieje instancja Microsoft SQL Server 2008 „MSSQLSERVER”, odpowiedni katalog „bin” Reporting Service prawdopodobnie znajduje się w:

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. Jeśli instalator MSI nie usunął pliku binarnego Aspose.Slides.ReportingServices.dll z powyższego katalogu podczas odinstalowywania Aspose.Slides for Reporting Services, usuń ten plik teraz.

6. Zlokalizuj plik **rsreportserver.config** dla każdej instancji SSRS. Na przykład, jeśli istnieje instancja Reporting Service „MSRS10.MSSQLSERVER”, plik **rsreportserver.config** będzie w tym katalogu:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. Otwórz plik **rsreportserver.config** w dowolnym edytorze i znajdź linie, które zostały dodane w celu włączenia rozszerzeń formatów PowerPoint podczas instalacji Aspose.Slides for Reporting Services. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>




```

**Krok** **8:** Jeśli instalator MSI nie usunął tych linii podczas odinstalowywania Aspose.Slides for Reporting Services, usuń je z pliku **rsreportserver.config** teraz.

**Krok** **9:** Zlokalizuj plik **rssrvpolicy.config** dla każdej instancji SSRS. Na przykład, jeśli istnieje instancja Reporting Service „MSRS10.MSSQLSERVER”, plik **rssrvpolicy.config** będzie w tym katalogu:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Krok** **10:** Otwórz plik **rssrvpolicy.config** w dowolnym edytorze i znajdź linie, które zostały utworzone w celu przyznania uprawnień wykonania Aspose.Slides for Reporting Services podczas instalacji tego produktu. 

**<CodeGroup>**

``` xml

   ...

  <CodeGroup>

    ...

    <!--Rozpocznij tutaj.-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="This code group grants full trust to the AS4SSRS assembly.">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

           PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--Zakończ tutaj.-->

  </CodeGroup>

</CodeGroup>



```

**Krok** **11:** Jeśli instalator MSI nie usunął powyższych linii podczas odinstalowywania produktu, usuń je z pliku **rssrvpolicy.config** teraz. 

**Krok** **12:** Jeśli Aspose.Slides for Reporting Services został również zainstalowany razem z Microsoft Visual Studio w celu tworzenia raportów RDL i eksportu do formatów PowerPoint w środowisku Microsoft Visual Studio, plik binarny Aspose.Slides.ReportingServices.dll oraz pliki konfiguracyjne (**rsreportserver.config** i **rssrvpolicy.config**) w przypadku Microsoft Visual Studio 2008 powinny znajdować się w:

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Krok** **13:** Jeśli instalator MSI nie usunął pliku binarnego **Aspose.Slides.ReportingServices.dll**, usuń go. Ponadto, jeśli nie zaktualizował plików **rsreportserver.config** i **rssrvpolicy.config**, aby usunąć rozszerzenia formatu PowerPoint oraz uprawnienia wykonywania kodu, musisz je usunąć ręcznie w taki sam sposób, jak w poprzednich krokach. 

**Krok** **14:** Nadszedł czas, aby ponownie zainstalować Aspose.Slides for Reporting Services. Użyj instalatora MSI do automatycznej instalacji lub wykonaj ją ręcznie.