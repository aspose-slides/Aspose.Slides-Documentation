---
title: Δημόσιο API και Μη Συμβατές Αναδρομικές Αλλαγές στην Aspose.Slides για Java 14.7.0
linktitle: Aspose.Slides for Java 14.7.0
type: docs
weight: 60
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- μετανάστευση
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των ανατρεπτικών αλλαγών στην Aspose.Slides για Java, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP σας."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα καταγράφει όλες τις [added](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., τυχόν νέους περιορισμούς και άλλες αλλαγές που εισήχθησαν με το Aspose.Slides for Java 14.7.0 API.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
### **Οι κατασκευαστές ορισμένων υποτύπων του TransitionValueBase έχουν αφαιρεθεί και η TransitionValueFactory έχει αφαιρεθεί**
Οι κατασκευητές ορισμένων υποτύπων του TransitionValueBase (και συγκεκριμένα CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) είναι άχρηστοι στο δημόσιο API και έτσι έχουν αφαιρεθεί. Η σχετική κλάση TransitionValueFactory και η διεπαφή της ITransitionValueFactory έχουν αφαιρεθεί για το ίδιο λόγο.
### **Το στοιχείο SoundAction έχει αφαιρεθεί από την απαρίθμηση com.aspose.slides.TransitionType**
Το στοιχείο SoundAction ήταν λανθασμένο και δεν χρησιμοποιείται. Οι ρυθμίσεις ήχου ορίζονται από τις ιδιότητες SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Η κλάση FlyThroughTransition και η διεπαφή IFlyThroughTransition έχουν προστεθεί**
Η κλάση com.aspose.slides.FlyThroughTransition (και η διεπαφή της com.aspose.slides.IFlyThroughTransition) σχετίζονται με τον τύπο μετάβασης Flythrough που υποστηρίζεται σε αυτήν την έκδοση.
### **Η κλάση GlitterTransition, η διεπαφή IGlitterTransition και η απαρίθμηση TransitionPattern έχουν προστεθεί**
Η κλάση com.aspose.slides.GlitterTransition (και η διεπαφή της com.aspose.slides.IGlitterTransition) σχετίζεται με τον τύπο μετάβασης Glitter που υποστηρίζεται σε αυτήν την έκδοση. Η απαρίθμηση com.aspose.slides.TransitionPattern χρησιμοποιείται σε αυτήν την κλάση και καθορίζει ένα γεωμετρικό μοτίβο που επαναλαμβάνεται για να καλύψει μια μεγαλύτερη περιοχή.
### **Η κλάση LeftRightDirectionTransition, η διεπαφή ILeftRightDirectionTransition και η απαρίθμηση TransitionLeftRightDirectionType έχουν προστεθεί**
Η κλάση com.aspose.slides.LeftRightDirectionTransition (και η διεπαφή της com.aspose.slides.ILeftRightDirectionTransition) σχετίζεται με τους τύπους μετάβασης Switch, Flip, Ferris, Gallery, Conveyor που υποστηρίζονται σε αυτήν την έκδοση. Η απαρίθμηση com.aspose.slides.TransitionLeftRightDirectionType χρησιμοποιείται σε αυτήν την κλάση και καθορίζει μια κατεύθυνση περιορισμένη στις τιμές αριστερά και δεξιά.
### **Νέα στοιχεία έχουν προστεθεί στην απαρίθμηση com.aspose.slides.TransitionType**
Η απαρίθμηση com.aspose.slides.TransitionType έχει επεκταθεί με νέα στοιχεία. Νέα στοιχεία σχετικά με τις νέες μεταβάσεις του PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Νέα στοιχεία σχετικά με τις νέες μεταβάσεις του PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Η κλάση RevealTransition και η διεπαφή IRevealTransition έχουν προστεθεί**
Η κλάση com.aspose.slides.RevealTransition (και η διεπαφή της com.aspose.slides.IRevealTransition) σχετίζεται με τον τύπο μετάβασης Reveal που υποστηρίζεται σε αυτήν την έκδοση.
Η κλάση RippleTransition, η διεπαφή IRippleTransition και η απαρίθμηση TransitionCornerAndCenterDirectionType έχουν προστεθεί
Η κλάση com.aspose.slides.RippleTransition (και η διεπαφή της com.aspose.slides.IRippleTransition) σχετίζεται με τον τύπο μετάβασης Ripple που υποστηρίζεται σε αυτήν την έκδοση. Η απαρίθμηση com.aspose.slides.TransitionCornerAndCenterDirectionType χρησιμοποιείται σε αυτήν την κλάση και καθορίζει μια κατεύθυνση περιορισμένη στις γωνίες και το κέντρο.
### **Η κλάση ShredTransition, η διεπαφή IShredTransition και η απαρίθμηση TransitionShredPattern έχουν προστεθεί**
Η κλάση com.aspose.slides.ShredTransition (και η διεπαφή της com.aspose.slides.IShredTransition) σχετίζεται με τον τύπο μετάβασης Shred που υποστηρίζεται σε αυτήν την έκδοση. Η απαρίθμηση com.aspose.slides.TransitionShredPattern χρησιμοποιείται σε αυτήν την κlass και καθορίζει ένα γεωμετρικό σχήμα που επαναλαμβάνεται για να καλύψει μια μεγαλύτερη περιοχή.