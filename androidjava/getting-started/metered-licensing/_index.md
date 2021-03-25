---
title: Metered Licensing
type: docs
weight: 100
url: /androidjava/metered-licensing/
---

{{% alert color="primary" %}} 

Aspose.Slides allows developers to apply metered key. It is a new licensing mechanism. The new licensing mechanism will be used along with existing licensing method. Those customers who want to be billed based on the usage of the API features can use the metered licensing. For more details, please refer to [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) section.

{{% /alert %}} 
## **Metered Licensing**
Here are the simple steps to use the Metered class.

1. Create an instance of Metered class.
1. Pass public & private keys to setMeteredKey method.
1. Do processing (perform task).
1. call method getConsumptionQuantity of the Metered class.
1. It will return the amount/quantity of API requests that you have consumed so far.

Following is the sample code demonstrating how to set metered public and private key.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slide-examples-ApplyLicense-MeteredLicensing-MeteredLicensing.java" >}}




