---
title: صادرات گزارش‌ها به قالب RPL
type: docs
weight: 110
url: /fa/reportingservices/exporting-reports-to-rpl-format/
---

{{% alert color="primary" %}} 
Aspose.Slides از گزارش‌ها در قالب RPL (Report Processing Language) برای رندرینگ استفاده می‌کند. این صفحه نحوه صادرات گزارش‌ها به قالب RPL را نشان می‌دهد.
{{% /alert %}} 

در بسیاری از سناریوها، مشتریان مجبورند گزارش‌های حاوی مشکلات را برای رفع به تیم Aspose اطلاع دهند. هنگامی که گزارش‌های به اشتراک گذاشته‌شده در قالب RDL باشند، مجموعه داده یا طرح‌واره نیز به اشتراک گذاشته می‌شود تا بتوانیم مشکل را بازتولید کنیم. گاهی حتی به اشتراک‌گذاری گزارش RDL همراه با مجموعه داده برای حل کامل مشکل کافی نیست. در این موارد، توصیه می‌کنیم گزارش‌ها را به قالب RPL صادر کرده و فایل RPL را برای گزارش به ما بفرستید. فایل RPL شامل مجموعه داده‌ای است که در آن استفاده شده است. به این ترتیب، صادرات به RPL آسان‌تر می‌شود و می‌تواند فوراً با ما به اشتراک گذاشته شود.

مراحل زیر را انجام دهید:

1. فایل Aspose.ReportingServices.Debug.Rpl.dll را به پوشه bin سرویس‌های Reporting کپی کنید (معمولاً در c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin قرار دارد).

{{% alert color="primary" %}} 
Aspose.ReportingServices.Debug.Rpl.dll در آخرین نسخه‌های Aspose.Slides برای Reporting Services موجود است که می‌توانید آن را از [صفحه انتشارها](https://releases.aspose.com/slides/fa/reportingservices/) دانلود کنید.
{{% /alert %}} 

2. این افزونه را به تگ **<Render>** در فایل **rsreportserver.config** اضافه کنید (معمولاً در c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config واقع است)

``` xml



//این برچسب را به عنصر <Render> اضافه کنید 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. مسیر فایل‌های RPL حاصل را با تغییر عنصر path مشخص کنید.

4. به Aspose.ReportingServices.Debug.Rpl.dll اجازه اجرا بدهید به این شکل: فایل C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config را باز کنید و این را به عنوان آخرین مورد در دومین عنصر **<CodeGroup>** بیرونی اضافه کنید (که باید به شکل **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">** باشد):

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--از اینجا شروع کنید.-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="Code group for my Aspose.Rpl.Debug rendering extension">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--در اینجا پایان.-->


  </CodeGroup>

</CodeGroup>


```

5. سرویس‌های Reporting را مجدداً راه‌اندازی کنید. باید گزینه Aspose.Rpl را در منوی Export پیدا کنید.

گزینه "Rpl export" باید در پنل خروجی ظاهر شود. شما باید گزارش را به قالب RPL صادر کنید و فایل RPL را به اشتراک بگذارید.