---
title: Getting Warning Callbacks for Fonts Substitution in Aspose.Slides
type: docs
weight: 90
url: /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides for Java makes it possible to get warning callbacks for fonts substitution in case the used font is not available on machine during rendering process. The warning callbacks are helpful in debugging the issues of missing or inaccessible fonts during rendering process.



{{% /alert %}} 

Aspose.Slides for Java provides a simple API methods to receive warning callbacks during the rendering process. Follow the steps below to configure the warning callbacks:

1. Create a custom callback class to receive the callbacks.
1. Set the warning callbacks using using LoadOptions class
1. Load the presentation file that is using a font for text inside that is unavailable on your target machine.
1. Generate the slide thumbnail to see the effect.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-FontSubstitution.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-IWarningCallback.java" >}}
