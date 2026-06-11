---
title: Instalacja ręczna
type: docs
weight: 30
url: /pl/reportingservices/install-manually/
---
{{% alert color="primary" %}} 

Postępuj zgodnie z poniższymi krokami tylko wtedy, gdy planujesz zainstalować Aspose.Slides for Reporting Services ręcznie. W takim przypadku pobrałeś pakiet ZIP zawierający pliki zestawów. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** wymaga zainstalowania **.NET Framework 3.5** na komputerze hosta. 

{{% /alert %}}

### **Instalacja ręczna**
Te instrukcje pokazują, jak kopiować i modyfikować pliki w katalogu, w którym zainstalowano Microsoft SQL Server Reporting Services:

1. Zlokalizuj katalog instalacji Report Server.  
   Katalog główny Microsoft SQL Server zwykle znajduje się tutaj: ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 i 2008**: Na maszynie może być skonfigurowanych kilka instancji Microsoft SQL Server i mogą one znajdować się w różnych podkatalogach MSSQL.x, takich jak MSSQL.1, MSSQL.2 itp. Musisz znaleźć właściwy katalog ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** zanim przejdziesz do kolejnego kroku. 
   
   {{% /alert %}} Wszystkie ścieżki użyte poniżej będą odnosiły się do tego katalogu jako <Instance>. 

2. Skopiuj Aspose.Slides.ReportingServices.dll do folderu **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin**.  
   Pobranie **Aspose.Slides.ReportingServices.zip** zawiera **Aspose.Slides.ReportingServices.dll**. {{% alert color="primary" %}} 

   W niektórych przypadkach, gdy kopiujesz plik DLL do katalogu **ReportServer\bin**, może on zostać skopiowany wraz z wyraźnie przypisanymi uprawnieniami NTFS. Uprawnienia NTFS powodują, że Microsoft SQL Server Reporting Services odmawia dostępu przy ładowaniu **Aspose.Slides.ReportingServices.dll**. Jeśli tak się stanie, nowe formaty eksportu nie będą dostępne. Sprawdź i potwierdź, że odpowiednie uprawnienia NTFS są ustawione :

   1. Kliknij prawym przyciskiem **Aspose.Slides.ReportingServices.dll**.  
   2. Wybierz **Properties** i przejdź do zakładki **Security**.  
   3. Usuń wszystkie wyraźnie przypisane uprawnienia NTFS i pozostaw tylko dziedziczone uprawnienia.  

   {{% /alert %}}

3. Zarejestruj Aspose.Slides for Reporting Services jako rozszerzenie renderowania:  
   1. Otwórz *C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*.  
   1. Dodaj poniższe wiersze do elementu <Render>:  

**<Render>**

``` xml

   ...

  <!--Rozpocznij tutaj.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--Zakończ tutaj.-->

</Render>



```

4. Przyznaj Aspose.Slides for Reporting Services uprawnienia do wykonywania:  
   1. Otwórz **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**.  
   1. Dodaj następujący fragment jako ostatni element w drugim od zewnątrz elemencie <CodeGroup> (który powinien mieć postać `<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">`).  

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

5. Zweryfikuj, czy Aspose.Slides for Reporting Services został pomyślnie zainstalowany:  
   1. Otwórz Report Manager i sprawdź listę dostępnych typów eksportu dla raportu.  

      {{% alert color="primary" %}} Możesz uruchomić Report Manager, otwierając przeglądarkę (Microsoft Internet Explorer 6.0 lub nowszy) i wpisując adres URL Report Managera w pasek adresu (domyślnie jest to http://<ComputerName>/Reports).  

      {{% /alert %}}

   1. Wybierz raport na serwerze.  
   1. Otwórz listę **Select Format**.  
      Powinieneś zobaczyć listę formatów eksportu dostarczonych przez Aspose.Slides for Reporting Services.  
   1. Wybierz **PPT – PowerPoint Presentation via Aspose.Slides**.  

   **Aspose.Slides for Reporting Services zainstalowano pomyślnie i nowe formaty eksportu są dostępne.**  

![todo:image_alt_text](install-manually_1.png)




6. Kliknij odnośnik **Export**.  
   Raport zostaje wygenerowany w wybranym formacie, wysłany do klienta i otwarty w odpowiedniej aplikacji. W naszym przypadku raport został otwarty w Microsoft PowerPoint.  

   **Raport PPT wygenerowany przez Aspose.Slides for Reporting Services.**  

![todo:image_alt_text](install-manually_2.png)

Pomyślnie zainstalowano Aspose.Slides for Reporting Services i wygenerowano raport jako prezentację Microsoft PowerPoint!