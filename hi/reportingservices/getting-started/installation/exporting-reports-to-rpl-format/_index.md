---
title: RPL फ़ॉर्मेट में रिपोर्ट निर्यात करना
type: docs
weight: 110
url: /hi/reportingservices/exporting-reports-to-rpl-format/
---
 

{{% alert color="primary" %}} 

Aspose.Slides रिपोर्टों को रेंडर करने के लिए RPL (Report Processing Language) फ़ॉर्मेट का उपयोग करता है। यह पृष्ठ दिखाता है कि रिपोर्टों को RPL फ़ॉर्मेट में कैसे निर्यात किया जाए।

{{% /alert %}} 

कई परिस्थितियों में, ग्राहकों को समस्याओं वाले रिपोर्टों को Aspose स्टाफ़ के साथ समाधान के लिए साझा करना पड़ता है। जब साझा किए गए रिपोर्ट RDL रूप में होते हैं, तो समस्या को दोहराने के लिये डेटा सेट या स्कीमा भी साझा किया जाता है। कभी‑कभी, डेटा सेट के साथ RDL रिपोर्ट को साझा करना पूरी तरह समस्या हल करने के लिये पर्याप्त नहीं रहता। ऐसे मामलों में, हम सलाह देते हैं कि आप रिपोर्टों को RPL फ़ॉर्मेट में निर्यात करें और हमें RPL फ़ाइल साझा करें। RPL फ़ाइल में उपयोग किया गया डेटा सेट भी शामिल होता है। इस प्रकार, RPL में निर्यात करना आसान हो जाता है और फ़ाइल को तुरंत हमारे साथ साझा किया जा सकता है।

इन चरणों को करें:

1. Aspose.ReportingServices.Debug.Rpl.dll को Reporting services के bin निर्देशिका में कॉपी करें (आमतौर पर c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin पर)।

{{% alert color="primary" %}} 

Aspose.ReportingServices.Debug.Rpl.dll Aspose.Slides for Reporting Services के नवीनतम संस्करणों में उपलब्ध है, जिसे आप [Releases page](https://releases.aspose.com/slides/hi/reportingservices/) से डाउनलोड कर सकते हैं।

{{% /alert %}} 

2. इस एक्सटेंशन को **<Render>** टैग में **rsreportserver.config** फ़ाइल (आमतौर पर c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config पर) जोड़ें।

``` xml



//इस टैग को <Render> तत्व में जोड़ें 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. पाथ तत्व को संशोधित करके उत्पन्न होने वाली RPL फ़ाइलों का पथ निर्दिष्ट करें।

4. Aspose.ReportingServices.Debug.Rpl.dll को इस तरह निष्पादन अनुमति दें: C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config खोलें और इसे दूसरे बाहरी **<CodeGroup>** तत्व के अंतिम आइटम के रूप में जोड़ें (जो **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">** होना चाहिए) :

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--यहाँ से शुरू करें।-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="Code group for my Aspose.Rpl.Debug rendering extension">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--यहाँ समाप्त करें।-->

  </CodeGroup>

</CodeGroup>


```

5. Reporting services को रीस्टार्ट करें। आपको Export मेनू में Aspose.Rpl विकल्प मिलना चाहिए।

"Rpl export" विकल्प एक्सपोर्ट पैनल पर दिखना चाहिए। आपको रिपोर्ट को RPL में निर्यात करना होगा और RPL फ़ाइल को साझा करना होगा।