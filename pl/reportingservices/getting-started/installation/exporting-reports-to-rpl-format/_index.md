---
title: Eksportowanie raportów do formatu RPL
type: docs
weight: 110
url: /pl/reportingservices/exporting-reports-to-rpl-format/
---
 

{{% alert color="primary" %}} 

Aspose.Slides używa raportów w formacie RPL (Report Processing Language) do renderowania. Ta strona pokazuje, jak wyeksportować raporty do formatu RPL.

{{% /alert %}} 

W wielu scenariuszach klienci muszą udostępniać raporty zawierające problemy w celu ich rozwiązania pracownikom Aspose. Gdy udostępniane raporty są w formacie RDL, zestaw danych lub schemat jest również przekazywany, aby umożliwić nam odtworzenie problemu. Czasami samo udostępnienie raportu RDL wraz ze zbiorem danych nie jest wystarczające, aby w pełni rozwiązać problem. W takich przypadkach zalecamy wyeksportowanie raportów w formacie RPL i udostępnienie nam pliku RPL. Plik RPL zawiera również używany zestaw danych. Dzięki temu eksport do RPL jest prostszy i może być od razu udostępniony nam.

Wykonaj następujące kroki:

1. Skopiuj Aspose.ReportingServices.Debug.Rpl.dll do katalogu bin usług raportowania (zwykle znajduje się w c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin).

{{% alert color="primary" %}} 

Aspose.ReportingServices.Debug.Rpl.dll jest dostępny w najnowszych wersjach Aspose.Slides dla Reporting Services, które można pobrać ze [strony wydań](https://releases.aspose.com/slides/pl/reportingservices/).

{{% /alert %}} 

2. Dodaj to rozszerzenie do znacznika **<Render>** w pliku **rsreportserver.config** (zwykle w c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)

``` xml



//Dodaj ten znacznik do elementu <Render>



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. Określ ścieżkę do wynikowych plików RPL, modyfikując element path.

4. Przyznaj Aspose.ReportingServices.Debug.Rpl.dll uprawnienia do wykonania w następujący sposób: otwórz C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config i dodaj to jako ostatni element w drugim od zewnątrz elemencie **<CodeGroup>** ( który powinien być **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">** ) :

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--Rozpocznij tutaj.-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="Code group for my Aspose.Rpl.Debug rendering extension">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--Zakończ tutaj.-->

  </CodeGroup>

</CodeGroup>
```

5. Zrestartuj usługi raportowania. Powinieneś znaleźć opcję Aspose.Rpl w menu Eksport.

Opcja „Rpl export” powinna pojawić się na panelu eksportu. Musisz wyeksportować raport do formatu RPL i udostępnić plik RPL.