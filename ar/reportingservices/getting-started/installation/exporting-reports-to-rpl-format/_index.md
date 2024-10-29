---
title: تصدير التقارير إلى تنسيق RPL
type: docs
weight: 110
url: /ar/reportingservices/exporting-reports-to-rpl-format/
---

﻿

{{% alert color="primary" %}} 

تستخدم Aspose.Slides التقارير بتنسيق RPL (لغة معالجة التقارير) للتقديم. توضح هذه الصفحة كيفية تصدير التقارير إلى تنسيق RPL﻿.

{{% /alert %}} 

في العديد من السيناريوهات، يتعين على العملاء مشاركة التقارير التي تحتوي على مشاكل لحلها مع موظفي Aspose. عندما تكون التقارير المشتركة في شكل RDL، يتم أيضًا مشاركة مجموعة البيانات أو المخطط للسماح لنا بزيادة إنتاجية المشكلة. في بعض الأحيان، حتى مشاركة تقرير RDL مع مجموعة البيانات ليست كافية لحل المشكلة تمامًا. في مثل هذه الحالات، نوصي بتصدير التقارير إلى تنسيق RPL ومشاركة ملف RPL للتقارير معنا. يتضمن ملف RPL مجموعة البيانات المستخدمة فيه أيضًا. بهذه الطريقة، يصبح من الأسهل تصدير إلى RPL ويمكن مشاركته على الفور معنا.

قم بتنفيذ هذه الخطوات:

1. انسخ إلى Aspose.ReportingServices.Debug.Rpl.dll إلى دليل bin لخدمات التقارير (عادةً في c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin).

{{% alert color="primary" %}} 

Aspose.ReportingServices.Debug.Rpl.dll متوفرة في أحدث إصدارات Aspose.Slides لخدمات التقارير، والتي يمكن تنزيلها من [صفحة الإصدارات](https://releases.aspose.com/slides/reportingservices/).

{{% /alert %}} 

2. أضف هذا الامتداد إلى علامة **<Render>** في ملف **rsreportserver.config** (عادةً في c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)

``` xml



//أضف هذه العلامة إلى عنصر <Render> 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. حدد المسار إلى ملفات RPL الناتجة عن طريق تعديل عنصر المسار.

4. منح Aspose.ReportingServices.Debug.Rpl.dll الأذونات لتنفيذ هذه الطريقة: افتح C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config وأضف هذا كآخر عنصر في العنصر الثاني من **<CodeGroup>** ( الذي يجب أن يكون **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">** ) :

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--ابدأ من هنا.-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="مجموعة التعليمات البرمجية للإضافات Aspose.Rpl.Debug للرسم">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--انتهى هنا.-->

  </CodeGroup>

</CodeGroup>


```

5. أعد تشغيل خدمات التقارير. يجب أن تجد خيار Aspose.Rpl في قائمة التصدير.

يجب أن يظهر خيار "تصدير Rpl" في لوحة التصدير. تحتاج إلى تصدير التقرير إلى RPL ومشاركة ملف RPL.