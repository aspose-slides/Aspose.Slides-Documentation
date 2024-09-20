---
title: Экспорт отчетов в формат RPL
type: docs
weight: 110
url: /reportingservices/exporting-reports-to-rpl-format/
---

﻿

{{% alert color="primary" %}} 

Aspose.Slides использует отчеты в формате RPL (Report Processing Language) для рендеринга. Эта страница демонстрирует, как экспортировать отчеты в формат RPL﻿.

{{% /alert %}} 

Во многих сценариях клиентам необходимо делиться отчетами, содержащими проблемы, для их разрешения с сотрудниками Aspose. Когда общие отчеты находятся в формате RDL, набор данных или структура также передаются, чтобы мы могли воспроизвести проблему. Иногда даже передача отчета в формате RDL вместе с набором данных не является достаточной для полного решения проблемы. В таких случаях мы рекомендуем экспортировать отчеты в формате RPL и поделиться файлом RPL для отчета с нами. Файл RPL также включает используемый в нем набор данных. Таким образом, экспорт в RPL становится проще, и его можно мгновенно отправить нам.

Выполните эти шаги:

1. Скопируйте Aspose.ReportingServices.Debug.Rpl.dll в каталог bin Reporting services (обычно по адресу c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin).

{{% alert color="primary" %}} 

Aspose.ReportingServices.Debug.Rpl.dll доступен в последних версиях Aspose.Slides для Reporting Services, который можно скачать со [страницы релизов](https://releases.aspose.com/slides/reportingservices/).

{{% /alert %}} 

2. Добавьте это расширение в **<Render>** тег файла **rsreportserver.config** (обычно по адресу c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)

``` xml

//Добавьте этот тег в элемент <Render> 

   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. Укажите путь к результирующим RPL файлам, изменив элемент path.

4. Дайте Aspose.ReportingServices.Debug.Rpl.dll права на выполнение таким образом: откройте C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config и добавьте это в качестве последнего элемента во втором внешнем элементе **<CodeGroup>** (который должен быть **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="Эта кодовая группа предоставляет разрешение на выполнение кода MyComputer. ">** ) :

``` xml

<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--Начать здесь.-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="Кодовая группа для моего расширения рендеринга Aspose.Rpl.Debug">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--Закончить здесь.-->

  </CodeGroup>

</CodeGroup>

```

5. Перезагрузите службы Reporting. Вы должны найти опцию Aspose.Rpl в меню Экспорт.

Опция "Экспорт Rpl" должна появиться на панели экспорта. Вам нужно экспортировать отчет в RPL и поделиться файлом RPL.